using System.Text.Json.Serialization;

namespace ContextCompiler.Readers.Modules.Excel.Configurations;

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
    [JsonPropertyName("headerRowIndex")] public int[]? HeaderRowIndex { get; set; }
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
