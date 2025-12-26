namespace ContextCompiler.Abstractions.Models;

public sealed record CompileOptions(
    int MaxCharacters = 120_000,
    string OutputFolderName = "out",
    string CacheFolderName = ".ctxboost/cache",
    string PluginsFolderName = ".ctxboost/plugins",
    string[]? IncludeGlobs = null,
    string[]? ExcludeGlobs = null
);
