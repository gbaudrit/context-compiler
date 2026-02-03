namespace ContextCompiler.Abstractions.Configuration;

public interface IConfigLocator
{
    string? Locate(string inputPath, string? providedPath, string name);
}
