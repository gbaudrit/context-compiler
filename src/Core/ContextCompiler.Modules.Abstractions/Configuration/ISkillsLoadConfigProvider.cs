namespace ContextCompiler.Modules.Abstractions.Configuration
{
    public interface ISkillsLoadConfigProvider
    {
        ISkillsLoadConfig Current { get; }

        ISkillsLoadConfig GetConfigOrDefault(string? configPath);
    }
}
