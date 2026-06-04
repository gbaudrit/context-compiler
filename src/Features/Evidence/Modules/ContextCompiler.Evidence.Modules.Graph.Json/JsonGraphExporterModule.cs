using System.Text.Json;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.CompilePipeline;

namespace ContextCompiler.Evidence.Modules.Graph.Json;

public sealed class JsonGraphExporterModule(IOutput output, ICompiledContext compiledContext) : IOutputArtifactComposerModule
{
    private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public ModuleMetadata Metadata => ICompilePipelineModule.Meta("evidence.graph.json", CompilePipelineModuleKinds.ReportComposition, priority: 0);

    public string Export(object graphModel)
    {
        return JsonSerializer.Serialize(graphModel, jsonSerializerOptions);
    }

    public async Task<IResult<ICompilePipelineRunResult>> Run(ICompilePipelineRunContext context, CancellationToken cancellationToken)
    {
        IGraph graph = await compiledContext.Graph(cancellationToken);
        output.AddArtifact(builder =>
        {
            return builder.WithFileName("evidence.graph.json")
                          .WithContent(JsonSerializer.Serialize(graph, jsonSerializerOptions))
                          .WithGeneratedBy(GetType());

        });

        return await context.Success();
    }
}
