using ContextCompiler.Rag.Modules.LocalInMemory.Models;

namespace ContextCompiler.Rag.Modules.LocalInMemory.Abstractions;

public interface IEmbeddingGenerator
{
    ValueTask<EmbeddingRecord> GenerateAsync(
        TextChunk chunk,
        CancellationToken cancellationToken = default);

    ValueTask<IReadOnlyList<EmbeddingRecord>> GenerateManyAsync(
        IReadOnlyList<TextChunk> chunks,
        CancellationToken cancellationToken = default);
}
