
namespace ContextCompiler.Abstractions.Workspace;

public interface IWorkspaceViewsLoader
{
    Task<IReadOnlyList<IWorkspaceView>> Load(string name);
}
