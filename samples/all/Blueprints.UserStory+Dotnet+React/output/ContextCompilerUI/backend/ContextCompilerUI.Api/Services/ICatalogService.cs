using ContextCompilerUI.Api.Models;

namespace ContextCompilerUI.Api.Services;

public interface ICatalogService
{
    Task<IReadOnlyList<ModuleItem>> GetModulesAsync();
    Task<IReadOnlyList<PackItem>> GetPacksAsync();
    Task<IReadOnlyList<BlueprintItem>> GetBlueprintsAsync();
}

public interface IArtifactsService
{
    Task<ArtifactsIndex?> GetArtifactsIndexAsync(string path);
}
