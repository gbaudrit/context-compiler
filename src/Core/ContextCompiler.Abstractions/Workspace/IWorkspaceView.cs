
namespace ContextCompiler.Abstractions.Workspace;

public interface IWorkspaceView
{
    string Name { get; init; }
    string Description { get; init; }
    string FilePath { get; init; }
    string Content { get; init; }
    DateTime LastModified { get; init; }

    IReadOnlyList<IWorkspaceViewContent> Contents { get; init; }
}
