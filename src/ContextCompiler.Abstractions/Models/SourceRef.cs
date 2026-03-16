namespace ContextCompiler.Abstractions.Models;

public sealed record SourceRef(string Id, string Path, string? Locator = null) : ISourceRef;
