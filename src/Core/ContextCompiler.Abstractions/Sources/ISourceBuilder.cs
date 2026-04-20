using ContextCompiler.Abstractions.Configuration.Sections;

namespace ContextCompiler.Abstractions.Sources;

public interface ISourceBuilder
{
    ISourceBuilder InitNew();
    ISourceBuilder InitFrom(ISource source);
    ISourceBuilder WithConfigSection(ISourceConfigSection sourceConfigSection);

    ISource Build();
    ISourceBuilder WithRootPath(string rootPath);
    ISourceBuilder WithAddedBy(string addedBy);
    ISourceBuilder WithIsExternal(bool isExternal);
    ISourceBuilder WithDynamicIncludes(IReadOnlyList<string> dynamicIncludes);
    ISourceBuilder WithDynamicExcludes(IReadOnlyList<string> dynamicExcludes);
}
