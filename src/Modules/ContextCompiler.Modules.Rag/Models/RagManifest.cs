namespace ContextCompiler.Modules.Rag.Models;

public sealed record RagManifest(
    string Model,
    string EmbeddingType,
    int Count,
    DateTimeOffset GeneratedAtUtc);
