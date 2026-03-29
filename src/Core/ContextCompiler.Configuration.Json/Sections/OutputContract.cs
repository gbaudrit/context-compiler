using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Configuration.Json.Sections;

public sealed class OutputContract : IOutputContract
{
    [JsonPropertyName("format")] public string? Format { get; set; }
    [JsonPropertyName("sections")] public List<string>? Sections { get; set; }
    [JsonPropertyName("style")] public IOutputStyle? Style { get; set; }
}
