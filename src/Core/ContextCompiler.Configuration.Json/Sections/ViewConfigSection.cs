using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Configuration.Sections;

using Microsoft.Extensions.Configuration;

namespace ContextCompiler.Configuration.Json.Sections;

public sealed class ViewConfigSection : IViewConfigSection
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
    [ConfigurationKeyName("select")]
    [JsonPropertyName("select")] public string[] SelectTags { get; set; } = [];
    [JsonPropertyName("excludes")] public string[] Excludes { get; set; } = [];
    [JsonPropertyName("order")] public string[] Order { get; set; } = [];
    [JsonPropertyName("includeFragmentContent")] public bool IncludeFragmentContent { get; set; } = true;
    [JsonPropertyName("maxContentChars")] public int? MaxContentChars { get; set; } = null;
    [JsonPropertyName("renderers")] public string[] Renderers { get; set; } = ["yaml", "index.json"];
    // future: add other types e.g., json, yaml, markdown
}
