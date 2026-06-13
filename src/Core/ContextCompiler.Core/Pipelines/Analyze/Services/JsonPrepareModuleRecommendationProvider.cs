using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Services.Analyze;

namespace ContextCompiler.Core.Pipelines.Analyze.Services;

internal sealed class JsonPrepareModuleRecommendationProvider : IPrepareModuleRecommendationProvider
{
    private const string ResourceName = "ContextCompiler.Core.Pipelines.Analyze.Catalog.prepare-modules.catalog.json";

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    public async Task<IReadOnlyCollection<PrepareModuleRecommendation>> GetRecommendationsAsync(CancellationToken cancellationToken)
    {
        await using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceName)
            ?? throw new InvalidOperationException($"Embedded prepare module catalog not found: {ResourceName}");

        PrepareModuleRecommendationCatalog? catalog = await JsonSerializer.DeserializeAsync<PrepareModuleRecommendationCatalog>(
            stream,
            JsonOptions,
            cancellationToken);

        return catalog?.PrepareModules ?? [];
    }

    private sealed class PrepareModuleRecommendationCatalog
    {
        [JsonPropertyName("prepareModules")]
        public List<PrepareModuleRecommendation> PrepareModules { get; set; } = [];
    }
}
