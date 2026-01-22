using System.Text.Json.Serialization;

namespace ContextCompiler.Abstractions.Configuration;

public interface ICtxcConfigProvider
{
    ICtxcConfig Current { get; }

    CtxcConfig GetConfigOrDefault(string? configPath);
}

public sealed class CtxcConfig : ICtxcConfig
{
    [JsonPropertyName("enabled")] public bool Enabled { get; set; } = true;
    [JsonPropertyName("project")] public ProjectInfo? Project { get; set; }
    [JsonPropertyName("objectives")] public Dictionary<string, string>? Objectives { get; set; }
    [JsonPropertyName("assumptions")] public Dictionary<string, string>? Assumptions { get; set; }
    [JsonPropertyName("constraints")] public ConstraintsInfo? Constraints { get; set; }
    [JsonPropertyName("glossary")] public Dictionary<string, string>? Glossary { get; set; }
    [JsonPropertyName("outputContract")] public OutputContract? OutputContract { get; set; }
    [JsonPropertyName("files")] public List<FileConfig> Files { get; set; } = [];
    [JsonPropertyName("personas")] public PersonasConfig? Personas { get; set; }
    [JsonPropertyName("context")] public ContextConfig Context { get; set; } = new();
    [JsonPropertyName("views")] public ViewsConfig Views { get; set; } = new();
    [JsonPropertyName("renderers")] public List<string> Renderers { get; set; } = ["prompt.context.md"];
}

public sealed class ContextConfig
{
    [JsonPropertyName("enabled")] public bool Enabled { get; set; } = true;
    [JsonPropertyName("project")] public ProjectInfo? Project { get; set; }
    [JsonPropertyName("objectives")] public List<string>? Objectives { get; set; }
    [JsonPropertyName("assumptions")] public List<string>? Assumptions { get; set; }
    [JsonPropertyName("constraints")] public ConstraintsInfo? Constraints { get; set; }
    [JsonPropertyName("glossary")] public Dictionary<string, string>? Glossary { get; set; }
    [JsonPropertyName("outputContract")] public OutputContract? OutputContract { get; set; }
}

public sealed class ProjectInfo
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("summary")] public string? Summary { get; set; }
    [JsonPropertyName("domain")] public string? Domain { get; set; }
    [JsonPropertyName("audience")] public Dictionary<string, string>? Audiences { get; set; }
}

public sealed class ConstraintsInfo
{
    [JsonPropertyName("canUseExternalSources")] public bool CanUseExternalSources { get; set; } = true;
    [JsonPropertyName("must")] public List<string>? Must { get; set; }
    [JsonPropertyName("mustNot")] public List<string>? MustNot { get; set; }
}

public sealed class OutputContract
{
    [JsonPropertyName("format")] public string? Format { get; set; }
    [JsonPropertyName("sections")] public List<string>? Sections { get; set; }
    [JsonPropertyName("style")] public OutputStyle? Style { get; set; }
}

public sealed class OutputStyle
{
    [JsonPropertyName("tone")] public string? Tone { get; set; }
    [JsonPropertyName("language")] public string? Language { get; set; }
}

public sealed class FileConfig
{
    [JsonPropertyName("includes")] public string[] Includes { get; set; } = [];
    [JsonPropertyName("excludes")] public string[] Excludes { get; set; } = [];
    [JsonPropertyName("subs")] public SubFilesMatchConfig[] Subs { get; set; } = [];
    [JsonPropertyName("tags")] public string[] Tags { get; set; } = [];
    [JsonPropertyName("excel")] public ExcelFileSection? Excel { get; set; }
    // future: add other types e.g., json, yaml, markdown
}

public sealed class SubFilesMatchConfig
{
    [JsonPropertyName("includes")] public string[] Includes { get; set; } = [];
    [JsonPropertyName("excludes")] public string[] Excludes { get; set; } = [];
    [JsonPropertyName("tags")] public string[] Tags { get; set; } = [];
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
    [JsonPropertyName("rename")] public Dictionary<string,string>? Rename { get; set; }
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

public sealed class ViewsConfig
{
    [JsonPropertyName("inline")] public bool? Inline { get; set; }
    [JsonPropertyName("views")] public ViewConfig[] Views { get; set; } = [];
}

public sealed class ViewConfig
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
    [JsonPropertyName("select")] public string[] Select { get; set; } = [];
    [JsonPropertyName("exclude")] public string[] Exclude { get; set; } = [];
    [JsonPropertyName("order")] public string[] Order { get; set; } = [];
    [JsonPropertyName("includeFragmentContent")] public bool IncludeFragmentContent { get; set; } = true;
    [JsonPropertyName("maxContentChars")] public int? MaxContentChars { get; set; } = null;
    [JsonPropertyName("renderer")] public string[] Renderer { get; set; } = ["yaml", "index.json"];
    // future: add other types e.g., json, yaml, markdown
}
