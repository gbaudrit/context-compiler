using ContextCompiler.Modules.Rag.Models;

namespace ContextCompiler.Modules.Rag.Abstractions;

public interface IEmbeddingGenerator
{
    ValueTask<EmbeddingRecord> GenerateAsync(
        TextChunk chunk,
        CancellationToken cancellationToken = default);

    ValueTask<IReadOnlyList<EmbeddingRecord>> GenerateManyAsync(
        IReadOnlyList<TextChunk> chunks,
        CancellationToken cancellationToken = default);
}
