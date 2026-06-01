namespace ContextCompiler.Abstractions.Models;

public sealed record SourceRef(string Id, Uri Uri, string? Locator = null) : ISourceRef;
