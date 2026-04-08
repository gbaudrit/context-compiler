namespace ContextCompiler.Abstractions.Compilation;

public interface ICompilationContext
{

    ICompilationContext Add(Action<IInputFilesDefinitionBuilder> build);

}
