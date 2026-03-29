using ContextCompiler.Abstractions.Workspace;

namespace ContextCompiler.Core.Workspace;

internal sealed record WorkspaceViewContent : IWorkspaceViewContent
{
    public required string FilePath { get; init; }
    public required string Content { get; init; }
    public required DateTime LastModified { get; init; }

}
