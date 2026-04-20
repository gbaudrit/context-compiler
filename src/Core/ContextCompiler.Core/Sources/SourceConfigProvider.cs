using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.Sources;

namespace ContextCompiler.Core.Sources;

public class SourceConfigProvider(IConfigProvider configProvider, IServiceProvider serviceProvider) : ISourceConfigProvider
{

    public IReadOnlyList<ISourceConfigSection> GetByOptionKey(string optionKey)
    {
        IRootConfigSection rootConfig = configProvider.Current;
        List<ISourceConfigSection> sourceConfigSections = [.. rootConfig.Sources];

        return sourceConfigSections.Where(file => file.OptionsKey == optionKey).ToList().AsReadOnly();
    }

    public IReadOnlyList<ISourceConfigSection> GetAll()
    {
        IRootConfigSection rootConfig = configProvider.Current;
        List<ISourceConfigSection> sourceConfigSections = [.. rootConfig.Sources];

        return sourceConfigSections.ToList().AsReadOnly();
    }

}
