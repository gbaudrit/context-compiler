using System.Text.Json.Serialization;

namespace ContextCompiler.Modules.Readers.Excel.Configurations;

public sealed class ExcelFileSection
{
    [JsonPropertyName("defaults")] public ExcelDefaults? Defaults { get; set; }
    [JsonPropertyName("extracts")] public List<ExcelExtractConfig> Extracts { get; set; } = [];
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
