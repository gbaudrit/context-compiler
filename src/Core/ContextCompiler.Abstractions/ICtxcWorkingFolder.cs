namespace ContextCompiler.Abstractions
{
    public interface ICtxcWorkingFolder
    {
        string Path { get; }

        string Combine(params string[] paths);
    }
}
