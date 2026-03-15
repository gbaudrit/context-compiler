using ContextCompiler.Modules.Rag.Models;

namespace ContextCompiler.Modules.Rag.Abstractions;

public interface IRagStore
{
    ValueTask AppendAsync(
        TextChunk chunk,
        EmbeddingRecord embedding,
        CancellationToken cancellationToken = default);

    ValueTask Flush(
        CancellationToken cancellationToken = default);
}
