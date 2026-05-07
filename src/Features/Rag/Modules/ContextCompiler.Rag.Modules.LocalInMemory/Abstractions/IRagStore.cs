using ContextCompiler.Rag.Modules.LocalInMemory.Models;

namespace ContextCompiler.Rag.Modules.LocalInMemory.Abstractions;

public interface IRagStore
{
    ValueTask AppendAsync(
        TextChunk chunk,
        EmbeddingRecord embedding,
        CancellationToken cancellationToken = default);

    ValueTask Flush(
        CancellationToken cancellationToken = default);
}
