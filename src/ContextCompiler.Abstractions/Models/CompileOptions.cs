namespace ContextCompiler.Abstractions.Models;

public sealed record CompileOptions(
    int MaxCharacters = 100_000_000,
    string OutputFolderName = "out",
    string CacheFolderName = ".ctxboost/cache",
    string PluginsFolderName = ".ctxboost/plugins",
    string[]? IncludeGlobs = null,
    string[]? ExcludeGlobs = null,
    string? ConfigPath = null
);
