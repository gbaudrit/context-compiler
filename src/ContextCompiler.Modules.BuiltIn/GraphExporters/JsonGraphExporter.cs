using System.Text.Json;

using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.BuiltIn.GraphExporters;

public sealed class PersonasActiveArtifact(IOutput output, IReasoningIr ir) : IOutputArtifactComposerModule
{
    private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public ModuleMetadata Metadata => BuiltInMetadata.Meta("builtin.output.evidence.graph.json", GlobalPipelineModuleKinds.OutputArtifactComposer, priority: 0);

    public string Export(object graphModel)
    {
        return JsonSerializer.Serialize(graphModel, jsonSerializerOptions);
    }

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
