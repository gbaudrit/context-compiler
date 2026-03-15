//using ContextCompiler.Modules.Rag.Abstractions;
//using ContextCompiler.Modules.Rag.Models;

//using SmartComponents.LocalEmbeddings;

//namespace ContextCompiler.Modules.Rag.Search;

//public sealed class SemanticSearchService(
//    LocalEmbedder embedder,
//    IRagStore ragStore) : ISemanticSearchService
//{
//    public async ValueTask<IReadOnlyList<SearchHit>> SearchAsync(
//        string query,
//        int maxResults = 5,
//        float? minSimilarity = null,
//        CancellationToken cancellationToken = default)
//    {
//        RagSnapshot? snapshot = await ragStore.LoadAsync(cancellationToken);
//        if (snapshot is null || snapshot.Chunks.Count == 0 || snapshot.Embeddings.Count == 0)
//        {
//            return [];
//        }

//        EmbeddingI8 target = embedder.Embed<EmbeddingI8>(query);

//        Dictionary<string, TextChunk> chunksById = snapshot.Chunks.ToDictionary(x => x.Id, x => x);

//        IEnumerable<(TextChunk Item, EmbeddingI8 Embedding)> candidates = snapshot.Embeddings
//            .Where(x => chunksById.ContainsKey(x.ChunkId))
//            .Select(x => (
//                Item: chunksById[x.ChunkId],
//                Embedding: new EmbeddingI8(x.Buffer)));

//        SimilarityScore<TextChunk>[] closest = LocalEmbedder.FindClosestWithScore(
//            target,
//            candidates,
//            maxResults,
//            minSimilarity);

//        return [.. closest
//            .Select(x => new SearchHit(
//                ChunkId: x.Item.Id,
//                ArtifactId: x.Item.ArtifactId,
//                Text: x.Item.Text,
//                Similarity: x.Similarity))];
//    }
//}
