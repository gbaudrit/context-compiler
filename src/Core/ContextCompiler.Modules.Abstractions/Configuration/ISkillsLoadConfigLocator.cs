namespace ContextCompiler.Modules.Abstractions.Configuration;

public interface ISkillsLoadConfigLocator
{
    string? Locate(string inputPath, string? providedPath, string name);
}
