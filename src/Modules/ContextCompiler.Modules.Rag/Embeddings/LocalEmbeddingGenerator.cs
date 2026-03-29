using ContextCompiler.Modules.Rag.Abstractions;
using ContextCompiler.Modules.Rag.Models;

using SmartComponents.LocalEmbeddings;

namespace ContextCompiler.Modules.Rag.Embeddings;

public sealed class LocalEmbeddingGenerator(LocalEmbedder embedder) : IEmbeddingGenerator
{
    public ValueTask<EmbeddingRecord> GenerateAsync(
        TextChunk chunk,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        EmbeddingI8 embedding = embedder.Embed<EmbeddingI8>(chunk.Text);

        return ValueTask.FromResult(new EmbeddingRecord(
            ChunkId: chunk.Id,
            Buffer: embedding.Buffer.ToArray(),
            EmbeddingType: nameof(EmbeddingI8)));
    }

    public ValueTask<IReadOnlyList<EmbeddingRecord>> GenerateManyAsync(
        IReadOnlyList<TextChunk> chunks,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        List<EmbeddingRecord> result = [];

        foreach (TextChunk chunk in chunks)
        {
            EmbeddingI8 embedding = embedder.Embed<EmbeddingI8>(chunk.Text);

            result.Add(new EmbeddingRecord(
                ChunkId: chunk.Id,
                Buffer: embedding.Buffer.ToArray(),
                EmbeddingType: nameof(EmbeddingI8)));
        }

        return ValueTask.FromResult<IReadOnlyList<EmbeddingRecord>>(result.AsReadOnly());
    }
}
