using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Configuration.Sections;

namespace ContextCompiler.Configuration.Json.Sections;

public sealed class ContextConfigSection : IContextConfigSection
{
    [JsonPropertyName("enabled")] public bool Enabled { get; set; } = true;
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("summary")] public string? Summary { get; set; }
    [JsonPropertyName("domain")] public string? Domain { get; set; }
    [JsonPropertyName("audiences")] public Dictionary<string, string>? Audiences { get; set; }
    [JsonPropertyName("objectives")] public List<string>? Objectives { get; set; }
    [JsonPropertyName("assumptions")] public List<string>? Assumptions { get; set; }
    [JsonPropertyName("constraints")] public ConstraintsInfo? ConstraintsValue { get; set; }

    [JsonIgnore]
    public IConstraintsInfo? Constraints => ConstraintsValue;

    [JsonPropertyName("glossary")] public Dictionary<string, string>? Glossary { get; set; }
    [JsonPropertyName("outputContract")] public OutputContract? OutputContractValue { get; set; }

    [JsonIgnore]
    public IOutputContract? OutputContract => OutputContractValue;
}
