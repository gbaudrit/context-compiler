using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Rag.Abstractions;

namespace ContextCompiler.Modules.Rag;

public sealed class RagEmbeddingsGeneratorModule(IRagIndexer ragIndexer, IPrompt prompt) : IFragmentProcessorModule
{
    public ModuleMetadata Metadata => IModule.Meta(
        "rag",
        GlobalPipelineModuleKinds.FragmentProcessor,
        priority: 100);

    public async Task Process(IFragment fragment, IDataPart dataPart, CancellationToken ct)
    {
        await ragIndexer.IndexAsync(new(
            fragment.Source.Path,
            fragment.Evidence.EvidenceKey,
            fragment.Source.Path,
            fragment.Content
        ), ct);
    }
}
