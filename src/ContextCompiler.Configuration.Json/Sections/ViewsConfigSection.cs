using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Configuration.Sections;

namespace ContextCompiler.Configuration.Json.Sections;

public sealed class ViewsConfigSection : IViewsConfigSection
{
    [JsonPropertyName("inline")] public bool? Inline { get; set; }
    [JsonPropertyName("views")] public IViewConfigSection[] Views { get; set; } = [];
}
