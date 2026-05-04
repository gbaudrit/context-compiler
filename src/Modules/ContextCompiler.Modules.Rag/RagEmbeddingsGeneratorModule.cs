using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Rag.Abstractions;

namespace ContextCompiler.Modules.Rag;

public sealed class RagEmbeddingsGeneratorModule(IRagIndexer ragIndexer, ISemanticSearchService semanticSearchService, IHasher hasher, ITokenChunker tokenChunker) : IDocumentPipelineModule
{
    public DocumentModuleMetadata Metadata => IDocumentPipelineModule.Meta(
        "rag",
        DocumentPipelineModuleKinds.FragmentsProcessor,
        priority: 100);

    public bool CanProcess(IDocumentContext documentContext)
    {
        return documentContext.Data.Fragments.Count > 0;
    }

    public async Task<IResult<IDocumentPipelineRunResult>> Run(IDocumentPipelineRunContext context, CancellationToken ct)
    {
        foreach (IFragment fragment in context.Document.Data.Fragments)
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
