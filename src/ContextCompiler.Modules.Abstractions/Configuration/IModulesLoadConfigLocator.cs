namespace ContextCompiler.Modules.Abstractions.Configuration;

public interface IModulesLoadConfigLocator
{
    string? Locate(string inputPath, string? providedPath, string name);
}
