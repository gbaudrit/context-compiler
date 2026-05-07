using ContextCompiler.Rag.Modules.LocalInMemory.Models;

namespace ContextCompiler.Rag.Modules.LocalInMemory.Abstractions
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
