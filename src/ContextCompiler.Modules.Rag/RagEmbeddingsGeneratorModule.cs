using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Rag.Abstractions;

using static System.Net.Mime.MediaTypeNames;

namespace ContextCompiler.Modules.Rag;

public sealed class RagEmbeddingsGeneratorModule(IRagIndexer ragIndexer, IPrompt prompt, ISemanticSearchService semanticSearchService, IHasher hasher) : IFragmentProcessorModule
{
    public ModuleMetadata Metadata => IModule.Meta(
        "rag",
        GlobalPipelineModuleKinds.FragmentProcessor,
        priority: 100);

    public async Task Process(IFragment fragment, IDataPart dataPart, CancellationToken ct)
    {

        var tokens = tokenizer.Encode(text);

        int chunkSize = 512;
        int overlap = 64;

        for (int i = 0; i < tokens.Count; i += chunkSize - overlap)
        {
            var chunk = tokens.Skip(i).Take(chunkSize);
            var chunkText = tokenizer.Decode(chunk);
        }

        await ragIndexer.IndexAsync(new(
            "RAG-" + hasher.Sha256Hex(fragment.Source.Id + "|" + fragment.Source.Locator + "|" + fragment.Evidence.EvidenceKey)[..32],
            fragment.Source.Id,
            fragment.Content,
            fragment.Source.Locator ?? ""
        ), ct);
    }
}
