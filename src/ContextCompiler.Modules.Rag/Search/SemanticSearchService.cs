using ContextCompiler.Modules.Rag.Abstractions;
using ContextCompiler.Modules.Rag.Models;

using SmartComponents.LocalEmbeddings;

namespace ContextCompiler.Modules.Rag.Search;

public sealed class SemanticSearchService(
    LocalEmbedder embedder,
    IRagStoreReader ragStoreReader) : ISemanticSearchService
{
    public async ValueTask<IReadOnlyList<SearchHit>> SearchAsync(
        string query,
        int maxResults = 5,
        float? minSimilarity = null,
        CancellationToken cancellationToken = default)
    {
        IReadOnlyList<TextChunk> chunks = await ragStoreReader.ReadChunksAsync(cancellationToken);
        IReadOnlyList<EmbeddingRecord> embeddings = await ragStoreReader.ReadEmbeddingsAsync(cancellationToken);

        if (chunks.Count == 0 || embeddings.Count == 0)
        {
            return [];
        }

        Dictionary<string, TextChunk> chunksById = chunks.ToDictionary(x => x.Id, x => x);

        EmbeddingI8 target = embedder.Embed<EmbeddingI8>(query);

        IEnumerable<(TextChunk Item, EmbeddingI8 Embedding)> candidates = embeddings
            .Where(x => x.EmbeddingType == nameof(EmbeddingI8))
            .Where(x => chunksById.ContainsKey(x.ChunkId))
            .Select(x => (
                Item: chunksById[x.ChunkId],
                Embedding: new EmbeddingI8(x.Buffer)));

        SimilarityScore<TextChunk>[] closest = LocalEmbedder.FindClosestWithScore(
            target,
            candidates,
            maxResults,
            minSimilarity);

        return [.. closest
            .Select(x => new SearchHit(
                ChunkId: x.Item.Id,
                ArtifactId: x.Item.ArtifactId,
                Text: x.Item.Text,
                Similarity: x.Similarity))];
    }
}
