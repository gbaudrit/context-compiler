using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Infrastructure.Configuration;

public sealed class DefaultConfigLocator : IConfigLocator
{
    public string? Locate(string inputPath, string? providedPath, string name)
    {
        string fileName = $"ctxc{(!string.IsNullOrEmpty(name) ? $".{name}" : "")}.config.json";

        if (!string.IsNullOrWhiteSpace(providedPath)) return providedPath;
        var candidateInRoot = System.IO.Path.Combine(inputPath, fileName);
        if (System.IO.File.Exists(candidateInRoot)) return candidateInRoot;
        var hiddenDir = System.IO.Path.Combine(inputPath, ".ctxc");
        var candidateHidden = System.IO.Path.Combine(hiddenDir, fileName);
        if (System.IO.File.Exists(candidateHidden)) return candidateHidden;

        throw new InvalidOperationException($"No config file found for context named {name}");
    }
}
