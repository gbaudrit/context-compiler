namespace ContextCompiler.Abstractions
{
    public interface IWorkingFolder
    {

        string Path { get; }

        string EnsureFullyQualifiedPath(string relativePath);
    }
}
