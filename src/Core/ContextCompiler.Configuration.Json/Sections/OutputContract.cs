using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Configuration;

using Microsoft.Extensions.Configuration;

namespace ContextCompiler.Configuration.Json.Sections;

public sealed class OutputContract : IOutputContract
{
    [JsonPropertyName("format")] public string? Format { get; set; }
    [JsonPropertyName("sections")] public List<string>? Sections { get; set; }
    [ConfigurationKeyName("style")]
    [JsonPropertyName("style")]
    public OutputStyle? StyleValue { get; set; }

    [JsonIgnore]
    public IOutputStyle? Style
    {
        get => StyleValue;
        set => StyleValue = value is null
            ? null
            : new OutputStyle
            {
                Tone = value.Tone,
                Language = value.Language,
            };
    }
}
