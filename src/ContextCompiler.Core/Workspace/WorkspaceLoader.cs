using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Workspace;

namespace ContextCompiler.Core.Workspace;

internal sealed class WorkspaceLoader(IWorkingFolder workingFolder, IWorkspaceViewsLoader workspaceViewsLoader) : IWorkspaceLoader, IWorkspaceAccessor
{

    private IWorkspace? _current;

    public IWorkspace Current => _current ?? Load().Result;

    public async Task<IWorkspace> Load()
    {
        _current = new Workspace()
        {
            Path = workingFolder.Path,
            Views = await workspaceViewsLoader.Load("")
        };
        return _current;
    }

}
