using ContextCompiler.Abstractions;

namespace ContextCompiler.Host.Mcp
{
    internal sealed class WorkingFolder(string path) : IWorkingFolder
    {
        public string Path => path;

        public string EnsureFullyQualifiedPath(string relativePath)
        {
            return System.IO.Path.Combine(Path, relativePath);
        }
    }


}
