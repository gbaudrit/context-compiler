namespace ContextCompiler.Abstractions.Models.Analyze;

public sealed class AnalyzePlan
{
    public required IReadOnlyDictionary<string, string> RecommendedPrepareModules { get; init; }

    public required IReadOnlyDictionary<string, string> RecommendedCompileModules { get; init; }

    public required IReadOnlyCollection<string> Technologies { get; init; }

    public required IReadOnlyCollection<string> Diagnostics { get; init; }
}
