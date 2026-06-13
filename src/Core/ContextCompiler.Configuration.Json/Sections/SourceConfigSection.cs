using System.Text.Json;
using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Configuration.Sections;

using Microsoft.Extensions.Configuration;

namespace ContextCompiler.Configuration.Json.Sections;

public partial class SourceConfigSection : ISourceConfigSection
{
    [JsonPropertyName("url")] public Uri Url { get; set; } = new Uri("file:///");
    [JsonPropertyName("includes")] public string[] Includes { get; set; } = [];
    [JsonPropertyName("excludes")] public string[] Excludes { get; set; } = [];
    [ConfigurationKeyName("subs")]
    [JsonPropertyName("subs")]
    public SubFilesMatchConfig[] SubsValue { get; set; } = [];

    [JsonIgnore]
    public ISubFilesMatchConfigSection[] Subs
    {
        get => SubsValue;
        set => SubsValue =
        [
            .. value.Select(x => x is SubFilesMatchConfig concrete
                ? concrete
                : new SubFilesMatchConfig
                {
                    Includes = x.Includes,
                    Excludes = x.Excludes,
                    Tags = x.Tags,
                })
        ];
    }

    [JsonPropertyName("tags")] public string[] Tags { get; set; } = [];
    [JsonPropertyName("options")] public JsonElement? Options { get; set; }

    public string OptionsKey => Options?.EnumerateObject().FirstOrDefault().Name ?? string.Empty;

    //[JsonPropertyName("excel")] public ExcelFileSection? Excel { get; set; }
    // future: add other types e.g., json, yaml, markdown
}
