using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Configuration.Sections;

namespace ContextCompiler.Configuration.Json.Sections;

public sealed class RootConfigSection : IRootConfigSection
{
    [JsonPropertyName("$schema")] public string Schema => "https://raw.githubusercontent.com/gbaudrit/context-compiler/refs/heads/main/schemas/v0.0.1/ctxc.config.schema.json";
    [JsonPropertyName("context")] public ContextConfigSection ContextValue { get; set; } = new ContextConfigSection();

    [JsonIgnore]
    public IContextConfigSection Context => ContextValue;

    [JsonPropertyName("personas")] public PersonasConfigSection? PersonasValue { get; set; }
    [JsonIgnore]
    public IPersonasConfigSection? Personas => PersonasValue;

    [JsonPropertyName("files")] public List<FileConfigSection> FilesValue { get; set; } = [];

    [JsonIgnore]
    public IEnumerable<IFileConfigSection> Files => FilesValue;

    [JsonPropertyName("views")] public ViewsConfigSection ViewsValue { get; set; } = new ViewsConfigSection();

    [JsonIgnore]
    public IViewsConfigSection Views => ViewsValue;

    [JsonPropertyName("renderers")] public List<string> Renderers { get; set; } = ["prompt.context.md"];

    public void AddFile(string[] Includes,
                string[] Excludes,
                ISubFilesMatchConfigSection[] Subs,
                string[] Tags,
                System.Text.Json.JsonElement? Options)
    {
        FileConfigSection fileConfig = new()
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
        FilesValue.Add(fileConfig);
    }
}
