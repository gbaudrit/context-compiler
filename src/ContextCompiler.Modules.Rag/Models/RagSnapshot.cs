namespace ContextCompiler.Modules.Rag.Models;

public sealed record RagSnapshot(
    RagManifest Manifest,
    IReadOnlyList<TextChunk> Chunks,
    IReadOnlyList<EmbeddingIndexEntry> Embeddings);
