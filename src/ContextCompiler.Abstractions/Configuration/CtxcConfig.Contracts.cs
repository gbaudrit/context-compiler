using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContextCompiler.Abstractions.Configuration;

public interface ICtxcConfigProvider
{
    ICtxcConfig Current { get; }

    CtxcConfig GetConfigOrDefault(string? configPath);
}

public sealed class CtxcConfig : ICtxcConfig
{
    [JsonPropertyName("files")] public List<FileConfig> Files { get; set; } = [];
    [JsonPropertyName("personas")] public PersonasConfig? Personas { get; set; }
    [JsonPropertyName("context")] public ContextConfig Context { get; set; } = new();
    [JsonPropertyName("views")] public ViewsConfig Views { get; set; } = new();
    [JsonPropertyName("renderers")] public List<string> Renderers { get; set; } = ["prompt.context.md"];
}

public sealed class ContextConfig
{
    [JsonPropertyName("enabled")] public bool Enabled { get; set; } = true;
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("summary")] public string? Summary { get; set; }
    [JsonPropertyName("domain")] public string? Domain { get; set; }
    [JsonPropertyName("audience")] public Dictionary<string, string>? Audiences { get; set; }
    [JsonPropertyName("objectives")] public List<string>? Objectives { get; set; }
    [JsonPropertyName("assumptions")] public List<string>? Assumptions { get; set; }
    [JsonPropertyName("constraints")] public ConstraintsInfo? Constraints { get; set; }
    [JsonPropertyName("glossary")] public Dictionary<string, string>? Glossary { get; set; }
    [JsonPropertyName("outputContract")] public OutputContract? OutputContract { get; set; }
}

public sealed class ProjectInfo
{
    
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

public partial class FileConfig
{
    [JsonPropertyName("includes")] public string[] Includes { get; set; } = [];
    [JsonPropertyName("excludes")] public string[] Excludes { get; set; } = [];
    [JsonPropertyName("subs")] public SubFilesMatchConfig[] Subs { get; set; } = [];
    [JsonPropertyName("tags")] public string[] Tags { get; set; } = [];
    [JsonPropertyName("options")] public JsonElement? Options { get; set; }

    //[JsonPropertyName("excel")] public ExcelFileSection? Excel { get; set; }
    // future: add other types e.g., json, yaml, markdown
}

public sealed class SubFilesMatchConfig
{
    [JsonPropertyName("includes")] public string[] Includes { get; set; } = [];
    [JsonPropertyName("excludes")] public string[] Excludes { get; set; } = [];
    [JsonPropertyName("tags")] public string[] Tags { get; set; } = [];
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
