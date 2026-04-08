namespace ContextCompiler.Abstractions
{
    public interface ICompiledWorkingFolder
    {
        string Path { get; }

        string Combine(string relativePath);
    }
}
