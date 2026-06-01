using ContextCompiler.Rag.Modules.LocalInMemory.Models;

namespace ContextCompiler.Rag.Modules.LocalInMemory.Abstractions;

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
