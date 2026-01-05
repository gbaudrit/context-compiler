using System.Text.Json.Serialization;

namespace ContextCompiler.Abstractions.Configuration;

public interface ICtxcConfigProvider
{
    ICtxcConfig Current { get; }

    CtxcConfig GetConfigOrDefault(string? configPath);
}

public sealed class CtxcConfig : ICtxcConfig
{
    [JsonPropertyName("files")] public List<FileConfig> Files { get; set; } = new();
    [JsonPropertyName("personas")] public PersonasConfig? Personas { get; set; }
    [JsonPropertyName("context")] public ContextConfig? Context { get; set; }
    [JsonPropertyName("views")] public ViewsConfig Views { get; set; } = new();
}

public sealed class FileConfig
{
    [JsonPropertyName("includes")] public string[] Includes { get; set; } = Array.Empty<string>();
    [JsonPropertyName("excludes")] public string[] Excludes { get; set; } = Array.Empty<string>();
    [JsonPropertyName("tags")] public string[] Tags { get; set; } = Array.Empty<string>();
    [JsonPropertyName("excel")] public ExcelFileSection? Excel { get; set; }
    // future: add other types e.g., json, yaml, markdown
}

public sealed class ExcelFileSection
{
    [JsonPropertyName("defaults")] public ExcelDefaults? Defaults { get; set; }
    [JsonPropertyName("extracts")] public List<ExcelExtractConfig> Extracts { get; set; } = new();
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
    [JsonPropertyName("rename")] public Dictionary<string,string>? Rename { get; set; }
    // filters
    [JsonPropertyName("where")] public List<WhereClause>? Where { get; set; }
    // fragmentation
    [JsonPropertyName("fragmenting")] public FragmentingSpec? Fragmenting { get; set; }
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

public sealed class ViewsConfig
{
    [JsonPropertyName("inline")] public bool? Inline { get; set; }
    [JsonPropertyName("views")] public ViewConfig[] Views { get; set; } = Array.Empty<ViewConfig>();
}

public sealed class ViewConfig
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
    [JsonPropertyName("select")] public string[] Select { get; set; } = Array.Empty<string>();
    [JsonPropertyName("exclude")] public string[] Exclude { get; set; } = Array.Empty<string>();
    [JsonPropertyName("order")] public string[] Order { get; set; } = Array.Empty<string>();
    [JsonPropertyName("includeFragmentContent")] public bool IncludeFragmentContent { get; set; } = true;
    [JsonPropertyName("maxContentChars")] public int? MaxContentChars { get; set; } = null;
    // future: add other types e.g., json, yaml, markdown
}
