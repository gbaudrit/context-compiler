using ContextCompiler.Abstractions;

namespace ContextCompiler.Core
{
    internal sealed class CtxcWorkingFolder(IWorkingFolder workingFolder) : ICtxcWorkingFolder
    {

        public string Path => System.IO.Path.Combine(workingFolder.Path, ".ctxc");

    }
}
