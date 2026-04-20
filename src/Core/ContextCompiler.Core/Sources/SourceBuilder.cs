using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.Sources;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Sources;

internal sealed class SourceBuilder(IServiceProvider serviceProvider) : ISourceBuilder
{
    private ISourceConfigSection? _configSection;
    private string? _rootPath;
    private string? _addedBy;
    private bool _isExternal;
    private IReadOnlyList<string> _dynamicIncludes = [];
    private IReadOnlyList<string> _dynamicExcludes = [];


    public ISourceBuilder InitNew()
    {
        _configSection = null;
        _rootPath = null;
        _addedBy = null;
        _isExternal = false;
        _dynamicIncludes = [];
        _dynamicExcludes = [];
        return this;
    }

    public ISourceBuilder InitFrom(ISource source)
    {
        _configSection = source.ConfigSection;
        _rootPath = source.RootPath;
        _addedBy = source.AddedBy;
        _isExternal = source.IsExternal;
        _dynamicIncludes = source.DynamicIncludes;
        _dynamicExcludes = source.DynamicExcludes;
        return this;
    }

    public ISourceBuilder WithConfigSection(ISourceConfigSection configSection)
    {
        _configSection = configSection;
        return this;
    }

    public ISourceBuilder WithRootPath(string rootPath)
    {
        _rootPath = rootPath;
        return this;
    }

    public ISourceBuilder WithAddedBy(string addedBy)
    {
        _addedBy = addedBy;
        return this;
    }

    public ISourceBuilder WithIsExternal(bool isExternal)
    {
        _isExternal = isExternal;
        return this;
    }

    public ISourceBuilder WithDynamicIncludes(IReadOnlyList<string> dynamicIncludes)
    {
        _dynamicIncludes = _dynamicIncludes.Count > 0 ? [.. _dynamicIncludes, .. dynamicIncludes] : dynamicIncludes;
        return this;
    }

    public ISourceBuilder WithDynamicExcludes(IReadOnlyList<string> dynamicExcludes)
    {
        _dynamicExcludes = _dynamicExcludes.Count > 0 ? [.. _dynamicExcludes, .. dynamicExcludes] : dynamicExcludes;
        return this;
    }

    public ISource Build()
    {
        ArgumentNullException.ThrowIfNull(_configSection, nameof(_configSection));

        return new Source()
        {
            ConfigSectionReader = serviceProvider.GetKeyedService<ISourceConfigSectionReader>(_configSection.OptionsKey) ?? serviceProvider.GetRequiredService<ISourceConfigSectionReader>(),
            IsExternal = _isExternal,
            RootPath = _rootPath ?? string.Empty,
            ConfigSection = _configSection,
            AddedBy = _addedBy ?? string.Empty,
        };
    }


}
