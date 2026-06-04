namespace ContextCompiler.Abstractions.Models.Prepare;

public sealed class PreparePlan
{
    public required IReadOnlyCollection<string> RecommendedSkills { get; init; }

    public required IReadOnlyCollection<string> RecommendedPipelines { get; init; }

    public required IReadOnlyCollection<string> IncludePatterns { get; init; }

    public required IReadOnlyCollection<string> ExcludePatterns { get; init; }
}
