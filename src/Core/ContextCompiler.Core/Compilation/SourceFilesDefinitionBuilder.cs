using ContextCompiler.Abstractions.Compilation;
using ContextCompiler.Abstractions.Sources;

namespace ContextCompiler.Core.Compilation;

internal sealed class SourceFilesDefinitionBuilder : ISourceFilesDefinitionBuilder
{
    private ISource? _source;
    private string[]? _includes;
    private string[]? _excludes;
    private string[]? _tags;

    public ISourceFilesDefinitionBuilder InitNew()
    {
        _source = null;
        _includes = null;
        _excludes = null;
        _tags = null;
        return this;
    }

    public ISourceFilesDefinitionBuilder FromSource(ISource source)
    {
        _source = source;
        return this;
    }

    public ISourceFilesDefinitionBuilder WithIncludes(string[] includes)
    {
        _includes = includes;
        return this;
    }

    public ISourceFilesDefinitionBuilder WithExcludes(string[] excludes)
    {
        _excludes = excludes;
        return this;
    }

    public ISourceFilesDefinitionBuilder WithTags(string[] tags)
    {
        _tags = tags;
        return this;
    }

    public IInputFilesDefinition Build()
    {
        return new InputFilesDefinition
        {
            Includes = _includes?.Select(x => Path.Combine(_source?.RootPath ?? string.Empty, x)).ToArray() ?? [],
            Excludes = _excludes?.Select(x => Path.Combine(_source?.RootPath ?? string.Empty, x)).ToArray() ?? [],
            Tags = _tags ?? []
        };
    }
}
