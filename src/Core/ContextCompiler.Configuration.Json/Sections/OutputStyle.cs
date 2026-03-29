using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Configuration.Json.Sections;

public sealed class OutputStyle : IOutputStyle
{
    [JsonPropertyName("tone")] public string? Tone { get; set; }
    [JsonPropertyName("language")] public string? Language { get; set; }
}
