using ContextCompiler.Rag.Modules.LocalInMemory.Abstractions;
using ContextCompiler.Rag.Modules.LocalInMemory.Models;

namespace ContextCompiler.Rag.Modules.LocalInMemory.Indexation;

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
