namespace ContextCompiler.Rag.Modules.LocalInMemory.Models;

public sealed record EmbeddingRecord(
    string ChunkId,
    byte[] Buffer,
    string EmbeddingType);
