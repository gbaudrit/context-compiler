using ContextCompiler.Abstractions.Configuration.Sections;

namespace ContextCompiler.Abstractions.Configuration
{
    public interface IConfigProvider
    {
        IRootConfigSection Current { get; }

        IRootConfigSection GetConfigOrDefault(string? configPath);
    }
}
