namespace ContextCompiler.Abstractions.Models.Prepare;

public sealed class ProjectClassification
{
    public required IReadOnlyCollection<string> Technologies { get; init; }

    public required IReadOnlyCollection<string> Frameworks { get; init; }

    public required IReadOnlyCollection<string> Languages { get; init; }
}
