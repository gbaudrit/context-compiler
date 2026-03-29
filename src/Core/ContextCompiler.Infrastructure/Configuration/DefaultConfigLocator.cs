using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Infrastructure.Configuration;

public sealed class DefaultConfigLocator : IConfigLocator
{
    public string? Locate(string inputPath, string? providedPath, string name)
    {
        string fileName = $"ctxc{(!string.IsNullOrEmpty(name) ? $".{name}" : "")}.config.json";

        if (!string.IsNullOrWhiteSpace(providedPath))
        {
            return providedPath;
        }

        string candidateInRoot = Path.Combine(inputPath, fileName);
        if (File.Exists(candidateInRoot))
        {
            return candidateInRoot;
        }

        string hiddenDir = Path.Combine(inputPath, ".ctxc");
        string candidateHidden = Path.Combine(hiddenDir, fileName);
        return File.Exists(candidateHidden)
            ? candidateHidden
            : throw new InvalidOperationException($"No config file found for context named {name}");
    }
}
