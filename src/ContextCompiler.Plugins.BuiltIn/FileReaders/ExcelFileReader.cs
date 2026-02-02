using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

using ClosedXML.Excel;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Tags;

namespace ContextCompiler.Plugins.BuiltIn.FileReaders;

public sealed class ExcelFileReaderPlugin(
    IFileReadResultBuilder fileReadResultBuilder,
    IFileContentBuilder fileContentBuilder,
    ICtxcConfigProvider cfgProvider,
    IDataEnvelopeBuilder dataEnvelopeBuilder,
    IDataPartBuilder dataPartBuilder,
    ITagsBuilder tagsBuilder) : IFileReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.excel.reader", GlobalPipelinePluginKinds.FileReader, priority: 10);

    public bool CanRead(string path)
    {
        var ext = Path.GetExtension(path);
        return ext.Equals(".xlsx", StringComparison.OrdinalIgnoreCase) || ext.Equals(".xlsm", StringComparison.OrdinalIgnoreCase);
    }

    //public Task<IFileReadResult> ReadAsync(string path, CancellationToken ct)
    //{
    //    ct.ThrowIfCancellationRequested();
    //    return Task.FromResult(fileReadResultBuilder.InitNew()
    //                                                .WithContent(fileContentBuilder.InitNew()
    //                                                                               .WithPath(path)
    //                                                                               .WithMediaType("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
    //                                                                               .WithReaderType<ExcelFileReader>()
    //                                                                               .Build()).Build());
    //}

    public async Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        var cfg = cfgProvider.GetConfigOrDefault(null);
        var options = documentContext.ExtractOptions.Deserialize<ExcelFileSection>() ?? new ExcelFileSection();

        //var fileExtracts = new List<(string match, ExcelDefaults? defaults, List<ExcelExtractConfig> extracts)>();
        //foreach (var f in cfg.Files)
        //{
        //    foreach (var s in f.Includes)
        //    {
        //        fileExtracts.Add((s, options.Defaults, options.Extracts));
        //    }

        //}

        using var ms2 = File.OpenRead(documentContext.FullPath ?? string.Empty);
        using var wb2 = new XLWorkbook(ms2);
        var parts = new List<IDataPart>();
        var sourcePath = documentContext.FullPath ?? string.Empty;

        foreach (var x in options.Extracts.OrderBy(e => e.Id, StringComparer.Ordinal))
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

public sealed class ExcelFileSection
{
    [JsonPropertyName("defaults")] public ExcelDefaults? Defaults { get; set; }
    [JsonPropertyName("extracts")] public List<ExcelExtractConfig> Extracts { get; set; } = [];
}

public sealed class ExcelDefaults
{
    [JsonPropertyName("maxRows")] public int? MaxRows { get; set; }
    [JsonPropertyName("trimCells")] public bool? TrimCells { get; set; }
    [JsonPropertyName("emptyRowPolicy")] public string? EmptyRowPolicy { get; set; } // skip|keep
    [JsonPropertyName("header")] public HeaderDefaults? Header { get; set; }
}

public sealed class HeaderDefaults
{
    [JsonPropertyName("mode")] public string? Mode { get; set; } // firstRow|explicit
    [JsonPropertyName("normalize")] public bool? Normalize { get; set; }
}

public sealed class ExcelExtractConfig
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    [JsonPropertyName("label")] public string? Label { get; set; }
    [JsonPropertyName("sheet")] public string Sheet { get; set; } = string.Empty;
    // source selector: one-of
    [JsonPropertyName("table")] public string? Table { get; set; }
    [JsonPropertyName("range")] public string? Range { get; set; }
    [JsonPropertyName("headerRowIndex")] public int? HeaderRowIndex { get; set; }
    [JsonPropertyName("skip")] public int? Skip { get; set; } // skip leading phantom lines before header/rows
    // projection
    [JsonPropertyName("select")] public List<string>? Select { get; set; }
    [JsonPropertyName("exclude")] public List<string>? Exclude { get; set; }
    [JsonPropertyName("rename")] public Dictionary<string, string>? Rename { get; set; }
    // filters
    [JsonPropertyName("where")] public List<WhereClause>? Where { get; set; }
    // fragmentation
    [JsonPropertyName("fragmenting")] public FragmentingSpec? Fragmenting { get; set; }
    [JsonPropertyName("tags")] public string[] Tags { get; set; } = [];
}

public sealed class FragmentingSpec
{
    [JsonPropertyName("mode")] public string Mode { get; set; } = "single"; // single|chunks|groupBy|rowWise
    [JsonPropertyName("maxRows")] public int? MaxRows { get; set; }
    [JsonPropertyName("by")] public string? By { get; set; }
}

public sealed class WhereClause
{
    [JsonPropertyName("col")] public string Column { get; set; } = string.Empty;
    [JsonPropertyName("op")] public string Op { get; set; } = "eq"; // eq,in,contains,gt,lt,gte,lte
    [JsonPropertyName("value")] public string Value { get; set; } = string.Empty;
}

//public sealed class ExcelFileReader(ICtxcConfigProvider cfgProvider, IDataEnvelopeBuilder dataEnvelopeBuilder, IDataPartBuilder dataPartBuilder, ITagsBuilder tagsBuilder) : IFileReader
//{
//    private bool disposedValue;

//    public ValueTask<IFileContent> ReadAsync(string path, CancellationToken ct)
//    {
//        ct.ThrowIfCancellationRequested();
//        return ValueTask.FromResult<IFileContent>(new ExcelFileContent
//        {
//            Stream = File.OpenRead(path)
//        });
//    }



//    private void Dispose(bool disposing)
//    {
//        if (!disposedValue)
//        {
//            if (disposing)
//            {
//                // TODO: dispose managed state (managed objects)
//            }

//            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
//            // TODO: set large fields to null
//            disposedValue = true;
//        }
//    }

//    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
//    // ~ExcelFileReader()
//    // {
//    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
//    //     Dispose(disposing: false);
//    // }

//    public void Dispose()
//    {
//        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
//        Dispose(disposing: true);
//        GC.SuppressFinalize(this);
//    }
//}

//public sealed class ExcelFileContent : IFileContent
//{
//    private bool disposedValue;
//    public required FileStream Stream { get; init; }
//    private bool _readen;

//    public Stream NextPart()
//    {
//        if (_readen)
//        {
//            return System.IO.Stream.Null;
//        }
//        _readen = true;
//        return Stream;
//    }

//    private void Dispose(bool disposing)
//    {
//        if (!disposedValue)
//        {
//            if (disposing)
//            {
//                Stream.Dispose();
//            }

//            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
//            // TODO: set large fields to null
//            disposedValue = true;
//        }
//    }

//    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
//    // ~ExcelFileContent()
//    // {
//    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
//    //     Dispose(disposing: false);
//    // }

//    public void Dispose()
//    {
//        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
//        Dispose(disposing: true);
//        GC.SuppressFinalize(this);
//    }
//}
