namespace ContextCompiler.Modules.Rag.Models;

public sealed record EmbeddingRecord(
    string ChunkId,
    byte[] Buffer,
    string EmbeddingType);
