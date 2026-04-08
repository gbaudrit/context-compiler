using ContextCompiler.Abstractions;

namespace ContextCompiler.Core;

internal sealed class CompiledWorkingFolder(IWorkingFolder workingFolder) : ICompiledWorkingFolder
{
    public string Combine(string relativePath)
    {
        return System.IO.Path.Combine(Path, relativePath);
    }

    public string Path => workingFolder.EnsureFullyQualifiedPath(".ctxc");

}
