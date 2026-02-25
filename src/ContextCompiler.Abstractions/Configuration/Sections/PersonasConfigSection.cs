using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ContextCompiler.Abstractions.Configuration.Sections;

public sealed class PersonasConfigSection : IPersonasConfigSection
{
    [JsonPropertyName("active")] public List<string> Active { get; set; } = [];
    [JsonPropertyName("mode"), DefaultValue("append")] public string Mode { get; set; } = "append"; // append|prepend|replace
    [JsonPropertyName("params")] public Dictionary<string, object>? Params { get; set; }
}
