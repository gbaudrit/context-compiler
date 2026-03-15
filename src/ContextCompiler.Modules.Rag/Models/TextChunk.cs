namespace ContextCompiler.Modules.Rag.Models;

public sealed record TextChunk(
    string Id,
    string ArtifactId,
    string Text,
    string Source);
