using ContextCompiler.Abstractions;

namespace ContextCompiler.Modules.Cli
{
    internal sealed class WorkingFolder(string path) : IWorkingFolder
    {
        public string Path => path;

        public string EnsureFullyQualifiedPath(string relativePath)
        {
            return System.IO.Path.Combine(Path, relativePath);
        }

        public string MakeRelative(string path)
        {
            return System.IO.Path.GetRelativePath(Path, path);
        }
    }
}
