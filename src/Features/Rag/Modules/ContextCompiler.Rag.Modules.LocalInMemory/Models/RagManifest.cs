namespace ContextCompiler.Rag.Modules.LocalInMemory.Models;

public sealed record RagManifest(
    string Model,
    string EmbeddingType,
    int Count,
    DateTimeOffset GeneratedAtUtc);
