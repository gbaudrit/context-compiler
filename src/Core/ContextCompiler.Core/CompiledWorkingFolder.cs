using ContextCompiler.Abstractions;

namespace ContextCompiler.Core;

internal sealed class CompiledWorkingFolder(IWorkingFolder workingFolder) : ICompiledWorkingFolder
{
    public string Path(string name)
    {
        return workingFolder.EnsureFullyQualifiedPath(System.IO.Path.Combine(".ctxc", string.IsNullOrEmpty(name) ? "compiled" : $"compiled.{name}"));
    }

    public string Path()
    {
        return Path("");
    }

}
