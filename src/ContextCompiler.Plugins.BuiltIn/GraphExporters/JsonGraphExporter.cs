using System.Globalization;
using System.Text;
using System.Text.Json;

using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Plugins.BuiltIn.GraphExporters;

public sealed class PersonasActiveArtifact(IOutput output, IReasoningIr ir) : IOutputArtifactComposerPlugin
{
    private JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.output.evidence.graph.json", GlobalPipelinePluginKinds.OutputArtifactComposer, priority: 0);

    public string Export(object graphModel)
        => JsonSerializer.Serialize(graphModel, jsonSerializerOptions);

    public async Task Run(CancellationToken cancellationToken)
    {
        IGraph graph = await ir.Graph(cancellationToken);
        output.AddArtifact(builder =>
        {
            return builder.WithFileName("reasoning.graph.json")
                          .WithContent(JsonSerializer.Serialize(graph, jsonSerializerOptions));

        });
    }
}
