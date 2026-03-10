namespace ContextCompiler.Abstractions
{
    public interface ICompiledWorkingFolder
    {
        string Path();
        string Path(string name);
    }
}
