using ContextCompiler.Abstractions.Models.Analyze;
using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Services.Analyze;

namespace ContextCompiler.Core.Pipelines.Analyze.Services;

internal sealed class AnalyzePlanner(
    IEnumerable<IPrepareModuleRecommendationProvider> recommendationProviders) : IAnalyzePlanner
{
    public async Task<AnalyzePlan> CreatePlanAsync(
        ProjectInventory inventory,
        ProjectClassification classification,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(inventory);
        ArgumentNullException.ThrowIfNull(classification);
        cancellationToken.ThrowIfCancellationRequested();

        Dictionary<string, string> prepareModules = new([], StringComparer.OrdinalIgnoreCase);

        foreach (IPrepareModuleRecommendationProvider provider in recommendationProviders)
        {
            IReadOnlyCollection<PrepareModuleRecommendation> recommendations = await provider.GetRecommendationsAsync(cancellationToken);
            foreach (PrepareModuleRecommendation recommendation in recommendations)
            {
                if (recommendation.Matches(inventory, classification))
                {
                    prepareModules[recommendation.PackageId] = recommendation.Version;
                }
            }
        }

        AnalyzePlan plan = new()
        {
            RecommendedPrepareModules = prepareModules,
            RecommendedCompileModules = new Dictionary<string, string>([], StringComparer.OrdinalIgnoreCase),
            Technologies = [.. classification.Technologies.OrderBy(x => x, StringComparer.OrdinalIgnoreCase)],
            Diagnostics = [],
        };

        return plan;
    }
}
