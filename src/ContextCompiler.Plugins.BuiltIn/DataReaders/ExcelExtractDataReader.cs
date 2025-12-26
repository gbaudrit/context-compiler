using ClosedXML.Excel;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.DataReaders;

public sealed class ExcelExtractDataReader(ICtxcConfigProvider cfgProvider) : IDataReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.data.excel.extract", PluginKinds.DataReader, priority: 9);

    public bool CanRead(DocumentContent doc) => doc.MediaType.Contains("spreadsheet", StringComparison.OrdinalIgnoreCase);

    public Task<DataEnvelope> ReadAsync(DocumentContent doc, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        var cfg = cfgProvider.GetConfigOrDefault(null);
        if (cfg.Excel is null || cfg.Excel.Files.Count == 0)
        {
            using var ms = new MemoryStream(doc.Bytes);
            using var wb = new XLWorkbook(ms);
            var sheets = new List<object>();
            foreach (var ws in wb.Worksheets)
            {
                var used = ws.RangeUsed();
                if (used is null) continue;
                var rows = new List<List<string>>();
                foreach (var row in used.Rows())
                {
                    var r = new List<string>();
                    foreach (var cell in row.Cells()) r.Add(cell.GetFormattedString());
                    rows.Add(r);
                }
                sheets.Add(new { name = ws.Name, rows });
            }
            return Task.FromResult(new DataEnvelope(DataShape.Tabular, new { sheets }, new Dictionary<string,string>{{"mediaType",doc.MediaType}}));
        }

        using var ms2 = new MemoryStream(doc.Bytes);
        using var wb2 = new XLWorkbook(ms2);
        var parts = new List<DataPart>();

        foreach (var f in cfg.Excel.Files)
        {
            var sourcePath = doc.Path ?? string.Empty;
            if (!GlobMatch(sourcePath, f.Match)) continue;

            foreach (var x in f.Extracts.OrderBy(e => e.Id, StringComparer.Ordinal))
            {
                var sheet = wb2.Worksheets.FirstOrDefault(ws => string.Equals(ws.Name, x.Sheet, StringComparison.Ordinal));
                if (sheet is null) continue;
                IXLRange range = sheet.RangeUsed()!;
                if (!string.IsNullOrEmpty(x.Range))
                {
                    range = sheet.Range(x.Range);
                }

                var rows = new List<List<string>>();
                foreach (var row in range.Rows())
                {
                    var r = new List<string>();
                    foreach (var cell in row.Cells()) r.Add(cell.GetFormattedString());
                    rows.Add(r);
                }

                var toSkip = x.Skip.GetValueOrDefault(0);
                if (toSkip > 0 && toSkip < rows.Count)
                {
                    rows = rows.Skip(toSkip).ToList();
                }

                var headerRowIndex = x.HeaderRowIndex ?? 0;
                if (headerRowIndex < 0) headerRowIndex = 0;
                if (rows.Count == 0) continue;
                var header = rows[Math.Min(headerRowIndex, rows.Count - 1)].ToArray();
                var body = rows.Skip(Math.Min(headerRowIndex + 1, rows.Count)).ToList();

                // apply where filters
                if (x.Where is not null && x.Where.Count > 0)
                {
                    foreach (var w in x.Where)
                    {
                        var colIndex = Array.FindIndex(header, h => string.Equals(h, w.Column, StringComparison.Ordinal));
                        if (colIndex < 0) continue;
                        body = body.Where(r => ApplyWhere(r[colIndex], w)).ToList();
                    }
                }

                // apply select projection
                if (x.Select is not null && x.Select.Count > 0)
                {
                    var desired = x.Select.OrderBy(s => s, StringComparer.Ordinal).ToArray();
                    var idxMap = desired.Select(col => Array.FindIndex(header, h => string.Equals(h, col, StringComparison.Ordinal))).ToArray();
                    // remove columns not found (index -1)
                    var valid = idxMap.Select((idx, i) => (idx, i)).Where(t => t.idx >= 0).ToArray();
                    var projHeader = valid.Select(t => desired[t.i]).ToList();
                    var projBody = body.Select(row => valid.Select(t => row[t.idx]).ToList()).ToList();
                    rows = new List<List<string>> { projHeader };
                    rows.AddRange(projBody);
                    header = projHeader.ToArray();
                    body = projBody;
                }

                var locatorPrefix = $"extract:{x.Id}/sheet:{x.Sheet}";
                if (!string.IsNullOrEmpty(x.Table)) locatorPrefix += $"/table:{x.Table}";
                if (!string.IsNullOrEmpty(x.Range)) locatorPrefix += $"/range:{x.Range}";

                var payload = new { headerRowIndex, rows };
                var env = new DataEnvelope(DataShape.Tabular, payload, new Dictionary<string,string>{{"extractId",x.Id},{"sheet",x.Sheet}});
                parts.Add(new DataPart(x.Id, new SourceRef(sourcePath, locatorPrefix), env, x.Label));
            }
        }

        if (parts.Count == 0)
        {
            return Task.FromResult(new DataEnvelope(DataShape.Tabular, new { parts = Array.Empty<object>() }));
        }

        var composite = new CompositeDataEnvelope(parts);
        return Task.FromResult(new DataEnvelope(DataShape.Composite, composite));
    }

    private static bool ApplyWhere(string value, WhereClause w)
    {
        var v = value ?? string.Empty;
        var cmp = StringComparison.Ordinal;
        return w.Op switch
        {
            "eq" => string.Equals(v, w.Value, cmp),
            "ne" => !string.Equals(v, w.Value, cmp),
            "neq" => !string.Equals(v, w.Value, cmp),
            "!=" => !string.Equals(v, w.Value, cmp),
            "in" => w.Value.Split('\u001f', StringSplitOptions.RemoveEmptyEntries).Contains(v),
            "contains" => v.Contains(w.Value, cmp),
            "gt" => string.Compare(v, w.Value, cmp) > 0,
            "lt" => string.Compare(v, w.Value, cmp) < 0,
            "gte" => string.Compare(v, w.Value, cmp) >= 0,
            "lte" => string.Compare(v, w.Value, cmp) <= 0,
            _ => true
        };
    }

    private static bool GlobMatch(string path, string pattern)
    {
        if (string.IsNullOrWhiteSpace(pattern)) return false;
        var p = pattern.Replace("\\", "/");
        var t = path.Replace("\\", "/");
        if (p == "**" || p == "*") return true;
        var parts = p.Split('/');
        var idx = 0;
        foreach (var part in parts)
        {
            if (part == "**") { idx = t.Length; continue; }
            if (part == "*")
            {
                var nextSlash = t.IndexOf('/', idx);
                if (nextSlash < 0) { idx = t.Length; continue; }
                idx = nextSlash + 1;
                continue;
            }
            var pos = t.IndexOf(part, idx, StringComparison.Ordinal);
            if (pos < 0) return false;
            idx = pos + part.Length;
        }
        return true;
    }
}
