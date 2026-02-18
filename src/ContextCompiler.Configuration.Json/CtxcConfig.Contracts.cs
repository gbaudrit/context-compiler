using System.Text.Json;
using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Configuration.Json;

public sealed class CtxcConfig : ICtxcConfig
{
    [JsonPropertyName("$schema")] public string Schema => "https://raw.githubusercontent.com/gbaudrit/context-compiler/refs/heads/main/schemas/v0.0.1/ctxc.config.schema.json";
    [JsonPropertyName("context")] public IContextConfig Context { get; set; } = new ContextConfig();
    [JsonPropertyName("personas")] public IPersonasConfig? Personas { get; set; }
    [JsonPropertyName("files")] public List<IFileConfig> Files { get; set; } = [];
    [JsonPropertyName("views")] public IViewsConfig Views { get; set; } = new ViewsConfig();
    [JsonPropertyName("renderers")] public List<string> Renderers { get; set; } = ["prompt.context.md"];

    public void AddFile(string[] Includes,
                string[] Excludes,
                ISubFilesMatchConfig[] Subs,
                string[] Tags,
                JsonElement? Options)
    {
        IFileConfig fileConfig = new FileConfig()
        {
            Includes = Includes,
            Excludes = Excludes,
            Subs = [.. Subs.Select(sub => new SubFilesMatchConfig()
            {
                Includes = sub.Includes,
                Excludes = sub.Excludes,
                Tags = sub.Tags
            })],
            Tags = Tags,
            Options = Options
        };
        Files.Add(fileConfig);
    }
}

public sealed class ContextConfig : IContextConfig
{
    [JsonPropertyName("enabled")] public bool Enabled { get; set; } = true;
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("summary")] public string? Summary { get; set; }
    [JsonPropertyName("domain")] public string? Domain { get; set; }
    [JsonPropertyName("audiences")] public Dictionary<string, string>? Audiences { get; set; }
    [JsonPropertyName("objectives")] public List<string>? Objectives { get; set; }
    [JsonPropertyName("assumptions")] public List<string>? Assumptions { get; set; }
    [JsonPropertyName("constraints")] public IConstraintsInfo? Constraints { get; set; }
    [JsonPropertyName("glossary")] public Dictionary<string, string>? Glossary { get; set; }
    [JsonPropertyName("outputContract")] public IOutputContract? OutputContract { get; set; }
}

public sealed class ProjectInfo
{

}

public sealed class ConstraintsInfo : IConstraintsInfo
{
    [JsonPropertyName("canUseExternalSources")] public bool CanUseExternalSources { get; set; } = true;
    [JsonPropertyName("must")] public List<string>? Must { get; set; }
    [JsonPropertyName("mustNot")] public List<string>? MustNot { get; set; }
}

public sealed class OutputContract : IOutputContract
{
    [JsonPropertyName("format")] public string? Format { get; set; }
    [JsonPropertyName("sections")] public List<string>? Sections { get; set; }
    [JsonPropertyName("style")] public IOutputStyle? Style { get; set; }
}

public sealed class OutputStyle : IOutputStyle
{
    [JsonPropertyName("tone")] public string? Tone { get; set; }
    [JsonPropertyName("language")] public string? Language { get; set; }
}

public partial class FileConfig : IFileConfig
{
    [JsonPropertyName("includes")] public string[] Includes { get; set; } = [];
    [JsonPropertyName("excludes")] public string[] Excludes { get; set; } = [];
    [JsonPropertyName("subs")] public ISubFilesMatchConfig[] Subs { get; set; } = [];
    [JsonPropertyName("tags")] public string[] Tags { get; set; } = [];
    [JsonPropertyName("options")] public JsonElement? Options { get; set; }

    //[JsonPropertyName("excel")] public ExcelFileSection? Excel { get; set; }
    // future: add other types e.g., json, yaml, markdown
}

public sealed class SubFilesMatchConfig : ISubFilesMatchConfig
{
    [JsonPropertyName("includes")] public string[] Includes { get; set; } = [];
    [JsonPropertyName("excludes")] public string[] Excludes { get; set; } = [];
    [JsonPropertyName("tags")] public string[] Tags { get; set; } = [];
}

public sealed class ViewsConfig : IViewsConfig
{
    [JsonPropertyName("inline")] public bool? Inline { get; set; }
    [JsonPropertyName("views")] public IViewConfig[] Views { get; set; } = [];
}

public sealed class ViewConfig : IViewConfig
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
    [JsonPropertyName("select")] public string[] SelectTags { get; set; } = [];
    [JsonPropertyName("exclude")] public string[] Exclude { get; set; } = [];
    [JsonPropertyName("order")] public string[] Order { get; set; } = [];
    [JsonPropertyName("includeFragmentContent")] public bool IncludeFragmentContent { get; set; } = true;
    [JsonPropertyName("maxContentChars")] public int? MaxContentChars { get; set; } = null;
    [JsonPropertyName("renderer")] public string[] Renderer { get; set; } = ["yaml", "index.json"];
    // future: add other types e.g., json, yaml, markdown
}
