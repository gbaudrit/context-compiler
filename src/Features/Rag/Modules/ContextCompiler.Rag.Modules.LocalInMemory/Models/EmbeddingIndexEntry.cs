namespace ContextCompiler.Rag.Modules.LocalInMemory.Models;

public sealed record EmbeddingIndexEntry(
    string ChunkId,
    long Offset,
    int Length,
    //byte[] Buffer,
    string EmbeddingType);
