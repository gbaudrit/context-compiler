using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Rag.Modules.LocalInMemory.Abstractions;

namespace ContextCompiler.Rag.Modules.LocalInMemory;

public sealed class RagEmbeddingsGeneratorModule(IRagIndexer ragIndexer, ISemanticSearchService semanticSearchService, IHasher hasher, ITokenChunker tokenChunker) : IInputIngestionPipelineModule
{
    public InputIngestionModuleMetadata Metadata => IInputIngestionPipelineModule.Meta(
        "rag",
        InputIngestionPipelineModuleKinds.FragmentsProcessor,
        priority: 100);

    public bool CanProcess(IInputItemContext InputItemContext)
    {
        return InputItemContext.Data.Fragments.Count > 0;
    }

    public async Task<IResult<IInputIngestionPipelineRunResult>> Run(IInputIngestionPipelineRunContext context, CancellationToken ct)
    {
        foreach (IFragment fragment in context.InputItem.Data.Fragments)
        {
            IReadOnlyList<string> chunks = await tokenChunker.SplitChunksByToken(fragment.Content, 256, 64, cancellationToken: ct);

            int index = 0;
            foreach (string chunk in chunks)
            {
                await ragIndexer.IndexAsync(new(
                    "RAG-" + hasher.Sha256Hex(fragment.Source.Id + "|" + fragment.Source.Locator + "|" + fragment.Evidence.EvidenceKey)[..32] + $"/{index}",
                    fragment.Source.Id,
                    chunk,
                    fragment.Source.Locator ?? ""
                ), ct);
                index++;
            }
        }

        return await context.NoChanges();

        //await ragIndexer.IndexAsync(new(
        //    "RAG-" + hasher.Sha256Hex(fragment.Source.Id + "|" + fragment.Source.Locator + "|" + fragment.Evidence.EvidenceKey)[..32],
        //    fragment.Source.Id,
        //    fragment.Content,
        //    fragment.Source.Locator ?? ""
        //), ct);
    }
}
