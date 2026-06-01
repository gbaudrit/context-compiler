using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Skills;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Skills.Modules.Artifacts.Enrichment;

/// <summary>
/// Module that enriches the output artifacts collection with skills from cache.
/// Runs during PrerequisitesEnrichment phase to register skills as artifacts before validation.
/// </summary>
public sealed class SkillsArtifactEnrichmentModule(
    ILogger<SkillsArtifactEnrichmentModule> logger,
    ISkillsLoadConfigProvider skillsConfigProvider,
    [FromKeyedServices(StoreKeys.Skills)] IStore skillsStore,
    IWorkingFolder workingFolder,
    IOutput output,
    IServiceProvider services) : IGlobalPipelineModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta(
        "skills-artifact-enrichment",
        GlobalPipelineModuleKinds.PrerequisitesEnrichment,
        priority: 1000
    );

    public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        logger.LogInformation("Scanning skills cache for artifact enrichment...");

        ISkillsLoadConfig config = skillsConfigProvider.Current;
        if (config.Items.Count == 0)
        {
            logger.LogInformation("No skills configured, skipping enrichment");
            return await context.Success();
        }

        logger.LogInformation("Using skills store: {StoreKey}", skillsStore.Key);

        string cacheRoot = ResolveWorkspacePath(config.CacheRoot);
        if (!Directory.Exists(cacheRoot))
        {
            logger.LogWarning("Skills cache directory not found: {CacheRoot}", cacheRoot);
            return await context.Success();
        }

        int enrichedCount = 0;

        foreach (KeyValuePair<string, string> skillEntry in config.Items)
        {
            string skillId = skillEntry.Key;
            string[] parts = skillId.Split('@');
            string name = parts.Length > 0 ? parts[0] : "unknown";
            string provider = parts.Length > 1 ? parts[1] : "unknown";
            string version = skillEntry.Value;

            try
            {
                ISkillProvider skillProvider = services.GetRequiredKeyedService<ISkillProvider>(provider);
                IReadOnlyList<ISkillInfos> skillsInfos = await skillProvider.GetSkillInfos(name, cancellationToken);

                foreach (ISkillInfos skillInfos in skillsInfos)
                {
                    IReadOnlyList<IStoreResource> resources = skillInfos.RestoreCacheContainer.GetResources("*", true);

                    foreach (IStoreResource resource in resources)
                    {
                        string resourcePath = resource.Uri.MakeRelativeOf(skillInfos.RestoreCacheContainer.Uri).ToString();
                        IStoreResource skillResource = skillsStore.Container.GetResource(resourcePath);

                        string content = await resource.ReadAllText(cancellationToken);

                        output.AddArtifact(builder => builder
                            .WithStoreResource(skillResource)
                            .WithCategory(ArtifactCategory.Skill)
                            .WithContent(content)
                            .WithDescription($"Skill file from {skillId}")
                            .WithGeneratedBy(typeof(SkillsArtifactEnrichmentModule))
                            .WithMimeType(GetMimeType(resource.Uri.AbsolutePath))
                            .WithMetadata("skillId", skillId)
                            .WithMetadata("provider", provider)
                            .WithMetadata("version", version)
                            .WithMetadata("sourcePath", resource.Uri.AbsolutePath)
                            .WithMetadata("excluded", "false")
                        );

                        enrichedCount++;
                    }

                    logger.LogInformation("Enriched {Count} files for skill {SkillId}", resources.Count, skillInfos.Id);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to enrich skill {SkillId}", skillId);
            }
        }

        logger.LogInformation("Skills artifact enrichment complete: {Count} files registered", enrichedCount);

        return await context.Success();
    }

    private string ResolveWorkspacePath(string path)
    {
        return Path.IsPathRooted(path)
            ? path
            : Path.GetFullPath(Path.Combine(workingFolder.Path, path.Replace('/', Path.DirectorySeparatorChar)));
    }

    private static string GetMimeType(string filePath)
    {
        return Path.GetExtension(filePath).ToLowerInvariant() switch
        {
            ".md" => "text/markdown",
            ".json" => "application/json",
            ".js" => "application/javascript",
            ".ts" => "application/typescript",
            ".py" => "text/x-python",
            ".yaml" or ".yml" => "application/x-yaml",
            ".txt" => "text/plain",
            _ => "application/octet-stream"
        };
    }
}
