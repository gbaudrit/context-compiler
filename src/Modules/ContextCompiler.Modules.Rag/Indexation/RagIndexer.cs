using ContextCompiler.Modules.Rag.Abstractions;
using ContextCompiler.Modules.Rag.Models;

namespace ContextCompiler.Modules.Rag.Indexation;

public sealed class RagIndexer(
 IEmbeddingGenerator embeddingGenerator,
 IRagStore ragStore)
 : IRagIndexer
{
    public async ValueTask IndexAsync(
        TextChunk chunk,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        EmbeddingRecord embedding =
            await embeddingGenerator.GenerateAsync(chunk, cancellationToken);

        await ragStore.AppendAsync(chunk, embedding, cancellationToken);
    }
}
