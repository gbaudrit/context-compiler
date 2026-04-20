namespace ContextCompiler.Abstractions.Compilation;

public interface ICompilationContext
{

    ICompilationContext Add(Func<ISourceFilesDefinitionBuilder, ISourceFilesDefinitionBuilder> build);

}
