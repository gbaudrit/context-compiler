namespace ContextCompiler.Plugins.Abstractions.Configuration
{
    public interface IPluginsLoadConfigProvider
    {
        IPluginsLoadConfig Current { get; }

        IPluginsLoadConfig GetConfigOrDefault(string? configPath);
    }
}
