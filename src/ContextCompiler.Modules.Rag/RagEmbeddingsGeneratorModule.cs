using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Rag.Abstractions;

namespace ContextCompiler.Modules.Rag;

public sealed class RagEmbeddingsGeneratorModule(IRagIndexer ragIndexer, IPrompt prompt, ISemanticSearchService semanticSearchService, IHasher hasher, ITokenChunker tokenChunker) : IFragmentProcessorModule
{
    public ModuleMetadata Metadata => IModule.Meta(
        "rag",
        GlobalPipelineModuleKinds.FragmentProcessor,
        priority: 100);

    public async Task Process(IFragment fragment, IDataPart dataPart, CancellationToken ct)
    {

        IReadOnlyList<string> chunks = await tokenChunker.SplitChunksByToken(fragment.Content, cancellationToken: ct);

        int index = 0;
        foreach (string chunk in chunks)
        {
            await ragIndexer.IndexAsync(new(
                "RAG-" + hasher.Sha256Hex(fragment.Source.Id + "|" + fragment.Source.Locator + "|" + fragment.Evidence.EvidenceKey)[..32] + $"/{index}",
                fragment.Source.Id,
                chunk,
                fragment.Source.Locator ?? ""
            ), ct);
        }

        //await ragIndexer.IndexAsync(new(
        //    "RAG-" + hasher.Sha256Hex(fragment.Source.Id + "|" + fragment.Source.Locator + "|" + fragment.Evidence.EvidenceKey)[..32],
        //    fragment.Source.Id,
        //    fragment.Content,
        //    fragment.Source.Locator ?? ""
        //), ct);
    }
}
