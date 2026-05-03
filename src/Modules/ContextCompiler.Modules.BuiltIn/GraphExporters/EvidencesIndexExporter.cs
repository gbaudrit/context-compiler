using System.Text.Json;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.BuiltIn.GraphExporters;

internal sealed class EvidencesIndexExporter(ILogger<EvidencesIndexExporter> logger, IReasoningIr ir, IPrompt prompt) : IOutputArtifactComposerModule
{
    public ModuleMetadata Metadata => BuiltInMetadata.Meta("builtin.output.artifact.evidence.index.json", GlobalPipelineModuleKinds.OutputArtifactComposer, priority: 10);

    private static readonly JsonSerializerOptions s_jsonIndentedOptions = new() { WriteIndented = true };

    public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        IGraph graph = await ir.Graph(cancellationToken);
        prompt.AddArtifact(builder =>
        {
            return builder.WithFileName("reasoning.graph.json")
                          .WithContent(JsonSerializer.Serialize(graph, s_jsonIndentedOptions))
                          .WithGeneratedBy(GetType());
        });

        return await context.Success();
    }
}
