using ContextCompiler.Abstractions.Workspace;

namespace ContextCompiler.Modules.Abstractions.Views;

public interface IViewDescriberModule
{
    bool CanProcess(IWorkspaceView view, IWorkspaceViewContent? content);
    Task<IViewDescription> Describe(IWorkspaceView view, IWorkspaceViewContent? content);

}
