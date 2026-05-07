namespace ContextCompiler.Rag.Modules.LocalInMemory.Models;

public sealed record RagSnapshot(
    RagManifest Manifest,
    IReadOnlyList<TextChunk> Chunks,
    IReadOnlyList<EmbeddingRecord> Embeddings);
