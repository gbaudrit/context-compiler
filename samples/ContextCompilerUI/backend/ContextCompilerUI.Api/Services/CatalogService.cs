using System.Text.Json;
using ContextCompilerUI.Api.Models;
using Microsoft.Extensions.Caching.Memory;

namespace ContextCompilerUI.Api.Services;

/// <summary>
/// Loads catalog data from static JSON files embedded under Data/.
/// Files can be replaced with a NuGet-discovery or registry source later.
/// </summary>
public sealed class CatalogService : ICatalogService
{
    private readonly IConfiguration _config;
    private readonly IMemoryCache _cache;
    private readonly ILogger<CatalogService> _logger;

    private static readonly JsonSerializerOptions JsonOpts = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public CatalogService(
        IConfiguration config,
        IMemoryCache cache,
        ILogger<CatalogService> logger)
    {
        _config = config;
        _cache = cache;
        _logger = logger;
    }

    public Task<IReadOnlyList<ModuleItem>> GetModulesAsync() =>
        LoadFromCacheAsync("modules", _config["CatalogPaths:ModulesCatalog"]!, ParseModules);

    public Task<IReadOnlyList<PackItem>> GetPacksAsync() =>
        LoadFromCacheAsync("packs", _config["CatalogPaths:PacksCatalog"]!, ParsePacks);

    public Task<IReadOnlyList<BlueprintItem>> GetBlueprintsAsync() =>
        LoadFromCacheAsync("blueprints", _config["CatalogPaths:BlueprintsCatalog"]!, ParseBlueprints);

    // --- private helpers ---

    private async Task<IReadOnlyList<T>> LoadFromCacheAsync<T>(
        string key,
        string filePath,
        Func<string, IReadOnlyList<T>> parser)
    {
        if (_cache.TryGetValue(key, out IReadOnlyList<T>? cached) && cached is not null)
            return cached;

        if (!File.Exists(filePath))
        {
            _logger.LogWarning("Catalog file not found: {Path}", filePath);
            return Array.Empty<T>();
        }

        var json = await File.ReadAllTextAsync(filePath);
        var result = parser(json);
        _cache.Set(key, result, TimeSpan.FromMinutes(5));
        return result;
    }

    private static IReadOnlyList<ModuleItem> ParseModules(string json) =>
        JsonSerializer.Deserialize<List<ModuleItem>>(json, JsonOpts) ?? [];

    private static IReadOnlyList<PackItem> ParsePacks(string json) =>
        JsonSerializer.Deserialize<List<PackItem>>(json, JsonOpts) ?? [];

    private static IReadOnlyList<BlueprintItem> ParseBlueprints(string json) =>
        JsonSerializer.Deserialize<List<BlueprintItem>>(json, JsonOpts) ?? [];
}

public sealed class ArtifactsService : IArtifactsService
{
    private static readonly JsonSerializerOptions JsonOpts = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task<ArtifactsIndex?> GetArtifactsIndexAsync(string path)
    {
        if (!File.Exists(path))
            return null;

        var json = await File.ReadAllTextAsync(path);
        return JsonSerializer.Deserialize<ArtifactsIndex>(json, JsonOpts);
    }
}
