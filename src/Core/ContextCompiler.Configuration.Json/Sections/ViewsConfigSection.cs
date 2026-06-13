using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Configuration.Sections;

using Microsoft.Extensions.Configuration;

namespace ContextCompiler.Configuration.Json.Sections;

public sealed class ViewsConfigSection : IViewsConfigSection
{
    [JsonPropertyName("inline")] public bool? Inline { get; set; }
    [ConfigurationKeyName("views")]
    [JsonPropertyName("views")] public List<ViewConfigSection> ViewsValue { get; set; } = [];

    [JsonIgnore]
    public List<IViewConfigSection> Views => [.. ViewsValue.Cast<IViewConfigSection>()];

    public void AddView(IViewConfigSection viewConfig)
    {
        if (viewConfig is ViewConfigSection v)
        {
            ViewsValue.Add(v);
        }
        else
        {
            throw new ArgumentException("Invalid view config type", nameof(viewConfig));
        }
    }
}
