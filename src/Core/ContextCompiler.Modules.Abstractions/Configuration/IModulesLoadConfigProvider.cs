namespace ContextCompiler.Modules.Abstractions.Configuration
{
    public interface IModulesLoadConfigProvider
    {
        IModulesLoadConfig Current { get; }

        IModulesLoadConfig GetConfigOrDefault(string? configPath);
    }

    public interface ISkillsLoadConfigProvider
    {
        SkillsConfig Current { get; }

        SkillsConfig GetConfigOrDefault(string? configPath);
    }
}
