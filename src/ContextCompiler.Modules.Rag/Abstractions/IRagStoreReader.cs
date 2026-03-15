using ContextCompiler.Modules.Rag.Models;

namespace ContextCompiler.Modules.Rag.Abstractions
{
    internal interface IRagStoreReader
    {
        ValueTask<RagManifest?> ReadManifestAsync(
        CancellationToken cancellationToken = default);

        IAsyncEnumerable<TextChunk> ReadChunksAsync(
            CancellationToken cancellationToken = default);

        IAsyncEnumerable<EmbeddingIndexEntry> ReadEmbeddingsAsync(
            CancellationToken cancellationToken = default);
    }
}
