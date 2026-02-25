using System.Text.Json;
using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Configuration.Sections;

namespace ContextCompiler.Configuration.Json.Sections;

public partial class FileConfigSection : IFileConfigSection
{
    [JsonPropertyName("includes")] public string[] Includes { get; set; } = [];
    [JsonPropertyName("excludes")] public string[] Excludes { get; set; } = [];
    [JsonPropertyName("subs")] public ISubFilesMatchConfigSection[] Subs { get; set; } = [];
    [JsonPropertyName("tags")] public string[] Tags { get; set; } = [];
    [JsonPropertyName("options")] public JsonElement? Options { get; set; }

    //[JsonPropertyName("excel")] public ExcelFileSection? Excel { get; set; }
    // future: add other types e.g., json, yaml, markdown
}
