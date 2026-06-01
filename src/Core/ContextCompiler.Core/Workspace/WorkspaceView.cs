using ContextCompiler.Abstractions.Workspace;

namespace ContextCompiler.Core.Workspace;

internal sealed record WorkspaceView : IWorkspaceView
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required string FilePath { get; init; }
    public required string Content { get; init; }
    public required DateTime LastModified { get; init; }
    public required IReadOnlyList<IWorkspaceViewContent> Contents { get; init; }
}
