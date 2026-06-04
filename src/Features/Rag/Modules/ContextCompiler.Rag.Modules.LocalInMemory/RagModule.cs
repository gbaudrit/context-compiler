using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Compile;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.CompilePipeline;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;

namespace ContextCompiler.Rag.Modules.LocalInMemory;

public sealed class RagModule : IConfigurationModule
{
    public ModuleMetadata Metadata => ICompilePipelineModule.Meta(
        "rag",
        CompilePipelineModuleKinds.Setup,
        priority: 100);

    public Task<IResult<ICompilePipelineRunResult>> Run(ICompilePipelineRunContext context, CancellationToken cancellationToken)
    {
        // TODO:
        // - lire la configuration RAG
        // - enregistrer les options/chunkers/indexeurs nécessaires
        // - préparer les artefacts .ctxc/rag si besoin
        return context.Success();
    }
}
