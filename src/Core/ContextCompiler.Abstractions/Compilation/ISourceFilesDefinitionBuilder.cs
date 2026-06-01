using ContextCompiler.Abstractions.Sources;

namespace ContextCompiler.Abstractions.Compilation;

public interface ISourceFilesDefinitionBuilder
{

    ISourceFilesDefinitionBuilder InitNew();
    ISourceFilesDefinitionBuilder WithIncludes(string[] includes);
    ISourceFilesDefinitionBuilder WithExcludes(string[] excludes);
    ISourceFilesDefinitionBuilder WithTags(string[] tags);

    IInputFilesDefinition Build();
    ISourceFilesDefinitionBuilder FromSource(ISource source);
}
