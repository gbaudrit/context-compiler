using ContextCompiler.Modules.Abstractions.Configuration;

namespace ContextCompiler.Modules.Loader.Configuration;

public sealed class ModulesConfigLocator : IModulesLoadConfigLocator
{
    public string? Locate(string inputPath, string? providedPath, string name)
    {
        string fileName = $"ctxc{(!string.IsNullOrEmpty(name) ? $".{name}" : "")}.modules.config.json";

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
