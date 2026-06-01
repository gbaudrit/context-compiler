
namespace ContextCompiler.Abstractions.Workspace;

public interface IWorkspaceViewContent
{
    string Content { get; init; }
    string FilePath { get; init; }
    DateTime LastModified { get; init; }
}
