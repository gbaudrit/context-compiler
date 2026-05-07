namespace ContextCompiler.Rag.Modules.LocalInMemory.Models;

public sealed record TextChunk(
    string Id,
    string ArtifactId,
    string Text,
    string Locator);
