using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Configuration.Json.Sections;

public sealed class ConstraintsInfo : IConstraintsInfo
{
    [JsonPropertyName("canUseExternalSources")] public bool CanUseExternalSources { get; set; } = true;
    [JsonPropertyName("must")] public List<string>? Must { get; set; }
    [JsonPropertyName("mustNot")] public List<string>? MustNot { get; set; }
}
