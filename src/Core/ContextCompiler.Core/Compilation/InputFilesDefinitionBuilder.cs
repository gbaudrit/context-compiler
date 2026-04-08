using ContextCompiler.Abstractions.Compilation;

namespace ContextCompiler.Core.Compilation;

internal sealed class InputFilesDefinitionBuilder : IInputFilesDefinitionBuilder
{
    private string[]? _includes;
    private string[]? _excludes;
    private string[]? _tags;

    public IInputFilesDefinitionBuilder InitNew()
    {
        _includes = null;
        _excludes = null;
        _tags = null;
        return this;
    }

    public IInputFilesDefinitionBuilder WithIncludes(string[] includes)
    {
        _includes = includes;
        return this;
    }

    public IInputFilesDefinitionBuilder WithExcludes(string[] excludes)
    {
        _excludes = excludes;
        return this;
    }

    public IInputFilesDefinitionBuilder WithTags(string[] tags)
    {
        _tags = tags;
        return this;
    }

    public IInputFilesDefinition Build()
    {
        return new InputFilesDefinition
        {
            Includes = _includes ?? [],
            Excludes = _excludes ?? [],
            Tags = _tags ?? []
        };
    }
}
