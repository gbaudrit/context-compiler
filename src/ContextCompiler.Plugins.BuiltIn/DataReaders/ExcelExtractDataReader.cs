using ClosedXML.Excel;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Tags;

namespace ContextCompiler.Plugins.BuiltIn.DataReaders;

public sealed class ExcelExtractDataReader(ICtxcConfigProvider cfgProvider, IDataEnvelopeBuilder dataEnvelopeBuilder, IDataPartBuilder dataPartBuilder, ITagsBuilder tagsBuilder) : IDataReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.data.excel.extract", GlobalPipelinePluginKinds.DataReader, priority: 9);

    public bool CanRead(IFileInfos doc) => doc.MediaType.Equals("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", StringComparison.OrdinalIgnoreCase);

    public async Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        var cfg = cfgProvider.GetConfigOrDefault(null);

        var fileExtracts = new List<(string match, ExcelDefaults? defaults, List<ExcelExtractConfig> extracts)>();
        foreach (var f in cfg.Files)
        {
            if (f.Excel is null) continue;
            foreach (var s in f.Includes)
            {
                fileExtracts.Add((s, f.Excel.Defaults, f.Excel.Extracts));
            }

        }

        using var ms2 = await documentContext.GetContentStream();
        using var wb2 = new XLWorkbook(ms2.NextPart());
        var parts = new List<IDataPart>();
        var sourcePath = documentContext.FullPath ?? string.Empty;

        foreach (var (match, defaults, extracts) in fileExtracts)
        {
            foreach (var x in extracts.OrderBy(e => e.Id, StringComparer.Ordinal))
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

                if (x.Where is not null && x.Where.Count > 0)
                {
                    foreach (var w in x.Where)
                    {
                        var colIndex = Array.FindIndex(header, h => string.Equals(h, w.Column, StringComparison.Ordinal));
                        if (colIndex < 0) continue;
                        body = body.Where(r => ApplyWhere(r[colIndex], w)).ToList();
                    }
                }

                if (x.Select is not null && x.Select.Count > 0)
                {
                    var desired = x.Select.OrderBy(s => s, StringComparer.Ordinal).ToArray();
                    var idxMap = desired.Select(col => Array.FindIndex(header, h => string.Equals(h, col, StringComparison.Ordinal))).ToArray();
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
                //var env = dataEnvelopeBuilder.InitNew()
                //                             .WithDataShape(DataShape.Tabular)
                //                             .WithPayload(payload)
                //                             .WithMetadata(new Dictionary<string, string> { { "extractId", x.Id }, { "sheet", x.Sheet } })
                //                             .Build();
                parts.Add(dataPartBuilder.InitNew()
                                          .WithId(x.Id)
                                          .WithSource(new SourceRef(sourcePath, locatorPrefix))
                                          .WithLabel(x.Label)
                                          .WithPayload(payload)
                                          .WithTags(tagsBuilder.InitNew().AddRange(x.Tags).Build())
                                          .Build());
            }
        }


        return dataEnvelopeBuilder.InitNew()
                                    .WithDataShape(DataShape.Tabular)
                                    .WithParts(parts)
                                    .Build();

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
}
