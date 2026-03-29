using ContextCompiler.Modules.Rag.Models;

namespace ContextCompiler.Modules.Rag.Abstractions;

internal interface IRagStoreWriter
{
    ValueTask WriteManifestAsync(
       RagManifest manifest,
       CancellationToken cancellationToken = default);

    ValueTask WriteChunkAsync(
        TextChunk chunk,
        CancellationToken cancellationToken = default);

    ValueTask WriteEmbeddingAsync(
        EmbeddingIndexEntry embedding,
        CancellationToken cancellationToken = default);

    ValueTask WriteFragmentAsync(
        TextChunk chunk,
        EmbeddingIndexEntry embedding,
        CancellationToken cancellationToken = default);

    ValueTask CompleteAsync(
        CancellationToken cancellationToken = default);
}
