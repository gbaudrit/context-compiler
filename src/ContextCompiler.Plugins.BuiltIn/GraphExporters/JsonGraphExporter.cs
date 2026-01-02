using System.Text.Json;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.GraphExporters;

public sealed class JsonGraphExporter : IGraphExporterPlugin
{
    private JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.graph.json", PluginKinds.GraphExporter, priority: 0);
    public string FormatId => "json";
    public string FileExtension => ".json";

    public string Export(object graphModel)
        => JsonSerializer.Serialize(graphModel, jsonSerializerOptions);
}
