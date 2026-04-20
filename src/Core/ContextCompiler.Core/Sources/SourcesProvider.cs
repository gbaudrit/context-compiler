using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.Sources;

namespace ContextCompiler.Core.Sources;

internal sealed class SourcesProvider(ISourceConfigProvider sourceConfigProvider, ISourceBuilder sourceBuilder, IWorkingFolder workingFolder, ICtxcWorkingFolder ctxcWorkingFolder) : ISourcesProvider
{

    public IReadOnlyList<ISource> GetByOptionKey(string optionKey)
    {
        IReadOnlyList<ISourceConfigSection> sourceConfigSections = sourceConfigProvider.GetByOptionKey(optionKey);

        return [.. sourceConfigSections.Select(BuildSourcesFromConfigSection)];
    }

    public IReadOnlyList<ISource> GetAll()
    {
        IReadOnlyList<ISourceConfigSection> sourceConfigSections = sourceConfigProvider.GetAll();
        return [.. sourceConfigSections.Select(BuildSourcesFromConfigSection)];
    }

    private ISource BuildSourcesFromConfigSection(ISourceConfigSection sourceConfigSection)
    {
        bool isExternal = !sourceConfigSection.Url.IsFile;
        string rootPath = isExternal
            ? ctxcWorkingFolder.Combine("externals")
            : workingFolder.Path;

        return sourceBuilder.InitNew()
            .WithConfigSection(sourceConfigSection)
            .WithIsExternal(isExternal)
            .WithRootPath(rootPath)
            .Build();
    }

}
