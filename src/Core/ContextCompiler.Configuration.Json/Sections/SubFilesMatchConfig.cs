using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Configuration.Sections;

namespace ContextCompiler.Configuration.Json.Sections;

public sealed class SubFilesMatchConfig : ISubFilesMatchConfigSection
{
    [JsonPropertyName("includes")] public string[] Includes { get; set; } = [];
    [JsonPropertyName("excludes")] public string[] Excludes { get; set; } = [];
    [JsonPropertyName("tags")] public string[] Tags { get; set; } = [];
}
