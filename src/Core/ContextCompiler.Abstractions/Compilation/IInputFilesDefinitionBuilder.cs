namespace ContextCompiler.Abstractions.Compilation;

public interface IInputFilesDefinitionBuilder
{

    IInputFilesDefinitionBuilder InitNew();
    IInputFilesDefinitionBuilder WithIncludes(string[] includes);
    IInputFilesDefinitionBuilder WithExcludes(string[] excludes);
    IInputFilesDefinitionBuilder WithTags(string[] tags);

    IInputFilesDefinition Build();
}
