namespace ContextCompiler.Abstractions.Workspace;

public interface IWorkspace
{
    IReadOnlyList<IWorkspaceView> Views { get; }

}
