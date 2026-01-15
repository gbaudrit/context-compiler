using System.Text.Json.Serialization;

namespace ContextCompiler.Abstractions.Configuration;

public sealed class ContextConfig
{
    [JsonPropertyName("enabled")] public bool Enabled { get; set; } = true;
    [JsonPropertyName("project")] public ProjectInfo? Project { get; set; }
    [JsonPropertyName("objectives")] public Dictionary<string, string>? Objectives { get; set; }
    [JsonPropertyName("assumptions")] public Dictionary<string, string>? Assumptions { get; set; }
    [JsonPropertyName("constraints")] public ConstraintsInfo? Constraints { get; set; }
    [JsonPropertyName("glossary")] public Dictionary<string,string>? Glossary { get; set; }
    [JsonPropertyName("outputContract")] public OutputContract? OutputContract { get; set; }
}

public sealed class ProjectInfo
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("summary")] public string? Summary { get; set; }
    [JsonPropertyName("domain")] public string? Domain { get; set; }
    [JsonPropertyName("audience")] public Dictionary<string, string>? Audiences { get; set; }
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
