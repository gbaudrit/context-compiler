using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Infrastructure.Configuration;

public sealed class DefaultConfigLocator : IConfigLocator
{
    public string? Locate(string inputPath, string? providedPath)
    {
        if (!string.IsNullOrWhiteSpace(providedPath)) return providedPath;
        var candidate = System.IO.Path.Combine(inputPath, "ctxc.config.json");
        return candidate;
    }
}
