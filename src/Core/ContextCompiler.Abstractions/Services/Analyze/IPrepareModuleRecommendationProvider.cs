using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Abstractions.Services.Analyze;

public interface IPrepareModuleRecommendationProvider
{
    Task<IReadOnlyCollection<PrepareModuleRecommendation>> GetRecommendationsAsync(CancellationToken cancellationToken);
}

public sealed class PrepareModuleRecommendation
{
    public required string PackageId { get; init; }

    public string Version { get; init; } = "*";

    public IReadOnlyCollection<string> Technologies { get; init; } = [];

    public IReadOnlyCollection<string> Extensions { get; init; } = [];

    public IReadOnlyCollection<string> Files { get; init; } = [];

    public bool Matches(ProjectInventory inventory, ProjectClassification classification)
    {
        ArgumentNullException.ThrowIfNull(inventory);
        ArgumentNullException.ThrowIfNull(classification);

        return Technologies.Any(t => classification.Technologies.Contains(t, StringComparer.OrdinalIgnoreCase))
            || Extensions.Any(e => inventory.Extensions.Contains(e, StringComparer.OrdinalIgnoreCase))
            || Files.Any(f => inventory.Files.Any(path => FileMatches(path, f)));
    }

    private static bool FileMatches(string path, string expected)
    {
        string normalizedPath = path.Replace('\\', '/');
        string normalizedExpected = expected.Replace('\\', '/');

        return string.Equals(normalizedPath, normalizedExpected, StringComparison.OrdinalIgnoreCase)
            || string.Equals(Path.GetFileName(normalizedPath), normalizedExpected, StringComparison.OrdinalIgnoreCase);
    }
}
