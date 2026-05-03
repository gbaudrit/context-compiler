using System.Text.Json;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.Evidences.Graph.Json;

public sealed class JsonGraphExporterModule(IPrompt prompt, IReasoningIr ir) : IOutputArtifactComposerModule
{
    private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("evidences.graph.json", GlobalPipelineModuleKinds.OutputArtifactComposer, priority: 0);

    public string Export(object graphModel)
    {
        return JsonSerializer.Serialize(graphModel, jsonSerializerOptions);
    }

    public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        IGraph graph = await ir.Graph(cancellationToken);
        prompt.AddArtifact(builder =>
        {
            return builder.WithFileName("reasoning.graph.json")
                          .WithContent(JsonSerializer.Serialize(graph, jsonSerializerOptions))
                          .WithGeneratedBy(GetType());

        });

        return await context.Success();
    }
}
