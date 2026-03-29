using ContextCompiler.Modules.Rag.Models;

namespace ContextCompiler.Modules.Rag.Abstractions
{
    public interface IRagStoreReader
    {
        ValueTask<RagManifest?> ReadManifestAsync(
         CancellationToken cancellationToken = default);

        ValueTask<IReadOnlyList<TextChunk>> ReadChunksAsync(
            CancellationToken cancellationToken = default);

        ValueTask<IReadOnlyList<EmbeddingRecord>> ReadEmbeddingsAsync(
            CancellationToken cancellationToken = default);
    }
}
