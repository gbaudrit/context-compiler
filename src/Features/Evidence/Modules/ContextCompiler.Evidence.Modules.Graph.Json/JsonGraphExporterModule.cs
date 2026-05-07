using System.Text.Json;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Evidence.Modules.Graph.Json;

public sealed class JsonGraphExporterModule(IOutput output, IReasoningIr ir) : IOutputArtifactComposerModule
{
    private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("evidence.graph.json", GlobalPipelineModuleKinds.ReportComposition, priority: 0);

    public string Export(object graphModel)
    {
        return JsonSerializer.Serialize(graphModel, jsonSerializerOptions);
    }

    public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        IGraph graph = await ir.Graph(cancellationToken);
        output.AddArtifact(builder =>
        {
            return builder.WithFileName("reasoning.graph.json")
                          .WithContent(JsonSerializer.Serialize(graph, jsonSerializerOptions))
                          .WithGeneratedBy(GetType());

        });

        return await context.Success();
    }
}
