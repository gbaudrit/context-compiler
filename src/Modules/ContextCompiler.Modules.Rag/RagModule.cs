using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.Rag;

public sealed class RagModule : IConfigurationModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta(
        "rag",
        GlobalPipelineModuleKinds.Setup,
        priority: 100);

    public Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        // TODO:
        // - lire la configuration RAG
        // - enregistrer les options/chunkers/indexeurs nécessaires
        // - préparer les artefacts .ctxc/rag si besoin
        return context.Success();
    }
}
