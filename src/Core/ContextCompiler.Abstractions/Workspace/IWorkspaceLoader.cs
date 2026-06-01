
namespace ContextCompiler.Abstractions.Workspace;

public interface IWorkspaceLoader
{
    Task<IWorkspace> Load();
}
