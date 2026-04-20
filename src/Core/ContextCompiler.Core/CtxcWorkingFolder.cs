using ContextCompiler.Abstractions;

namespace ContextCompiler.Core
{
    internal sealed class CtxcWorkingFolder(IWorkingFolder workingFolder) : ICtxcWorkingFolder
    {

        public string Path => System.IO.Path.Combine(workingFolder.Path, ".ctxc");

        public string Combine(params string[] paths)
        {
            string[] allPaths = new string[paths.Length + 1];
            allPaths[0] = Path;
            Array.Copy(paths, 0, allPaths, 1, paths.Length);
            return System.IO.Path.Combine(allPaths);
        }

    }
}
