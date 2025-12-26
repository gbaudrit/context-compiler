namespace ContextCompiler.Abstractions.Models;

public sealed record DocumentContent(
    string Path,
    string MediaType,
    byte[] Bytes,
    string? Text = null,
    IReadOnlyDictionary<string, string>? Metadata = null
);
