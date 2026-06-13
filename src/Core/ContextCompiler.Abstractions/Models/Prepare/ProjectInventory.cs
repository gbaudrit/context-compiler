namespace ContextCompiler.Abstractions.Models.Prepare;

public sealed class ProjectInventory
{
    public required IReadOnlyCollection<string> Extensions { get; init; }

    public required IReadOnlyCollection<string> Directories { get; init; }
    public required IReadOnlyCollection<string> Files { get; init; }

    public required IReadOnlyCollection<string> Technologies { get; init; }

    public int FileCount { get; init; }
}
