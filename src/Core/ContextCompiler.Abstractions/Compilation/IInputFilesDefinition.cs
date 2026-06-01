namespace ContextCompiler.Abstractions.Compilation;

public interface IInputFilesDefinition
{

    string[] Includes { get; }
    string[] Excludes { get; }
    string[] Tags { get; }

}
