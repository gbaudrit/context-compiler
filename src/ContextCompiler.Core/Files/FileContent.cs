using ContextCompiler.Abstractions.Files;

namespace ContextCompiler.Core.Files;

public sealed record FileContent(
    string Path,
    string MediaType,
    Type ReaderType,
    string? Text = null,
    IReadOnlyDictionary<string, string>? Metadata = null
) : IFileInfos;
