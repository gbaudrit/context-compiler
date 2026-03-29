using ContextCompiler.Abstractions.Workspace;

namespace ContextCompiler.Core.Workspace;

internal sealed record Workspace : IWorkspace
{
    public required string Path { get; init; }

    public required IReadOnlyList<IWorkspaceView> Views { get; init; }

}
