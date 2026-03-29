using ContextCompiler.Abstractions;

namespace ContextCompiler.Mcp.Infrastructure
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
