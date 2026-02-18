namespace ContextCompiler.Plugins.Abstractions.Configuration;

public interface IPluginsLoadConfigLocator
{
    string? Locate(string inputPath, string? providedPath, string name);
}
