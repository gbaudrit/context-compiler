using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.Rag;

public sealed class RagModule : IConfigurationModule
{
    public ModuleMetadata Metadata => IModule.Meta(
        "rag",
        GlobalPipelineModuleKinds.Configuration,
        priority: 100);

    public Task Run(CancellationToken cancellationToken)
    {
        // TODO:
        // - lire la configuration RAG
        // - enregistrer les options/chunkers/indexeurs nécessaires
        // - préparer les artefacts .ctxc/rag si besoin
        return Task.CompletedTask;
    }
}
