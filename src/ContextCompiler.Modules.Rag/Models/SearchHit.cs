namespace ContextCompiler.Modules.Rag.Models;

public sealed record SearchHit(
    string ChunkId,
    string ArtifactId,
    string Text,
    float Similarity);
