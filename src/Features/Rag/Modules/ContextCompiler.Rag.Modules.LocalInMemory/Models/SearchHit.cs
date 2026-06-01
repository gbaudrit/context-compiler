namespace ContextCompiler.Rag.Modules.LocalInMemory.Models;

public sealed record SearchHit(
    string ChunkId,
    string ArtifactId,
    string Locator,
    string Text,
    float Similarity);
