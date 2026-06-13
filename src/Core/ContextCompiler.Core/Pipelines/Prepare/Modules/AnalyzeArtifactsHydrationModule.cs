using System.Text.Json;
using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Pipelines.Prepare;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions.Pipelines.Prepare;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Pipelines.Prepare.Modules;

internal sealed class AnalyzeArtifactsHydrationModule(
    [FromKeyedServices(StoreKeys.Prepare)] IStore prepareStore) : IPreparePipelineModule
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    public PreparePipelineModuleMetadata Metadata =>
        IPreparePipelineModule.Meta("prepare.analyze-artifacts-hydration", PreparePipelineModuleKinds.SourceDiscovery);

    public async Task<IResult<IPreparePipelineRunResult>> Run(
        IPreparePipelineRunContext context,
        CancellationToken cancellationToken)
    {
        IStoreResource inventoryResource = prepareStore.Container.GetResource("inventory.json");
        IStoreResource classificationResource = prepareStore.Container.GetResource("classification.json");

        if (!await inventoryResource.Exists() || !await classificationResource.Exists())
        {
            return await context.Failure("Analyze artifacts are missing. Run 'ctxc analyze' before 'ctxc prepare'.");
        }

        InventoryEnvelope? inventoryEnvelope = JsonSerializer.Deserialize<InventoryEnvelope>(
            await inventoryResource.ReadAllText(cancellationToken),
            JsonOptions);

        ClassificationEnvelope? classificationEnvelope = JsonSerializer.Deserialize<ClassificationEnvelope>(
            await classificationResource.ReadAllText(cancellationToken),
            JsonOptions);

        if (inventoryEnvelope is null || classificationEnvelope is null)
        {
            return await context.Failure("Analyze artifacts could not be read.");
        }

        _ = context.WithInventory(new ProjectInventory
        {
            Extensions = inventoryEnvelope.Extensions,
            Directories = inventoryEnvelope.Directories,
            Files = inventoryEnvelope.Files,
            Technologies = inventoryEnvelope.Technologies,
            FileCount = inventoryEnvelope.FileCount,
        });

        _ = context.WithClassification(new ProjectClassification
        {
            Technologies = classificationEnvelope.Technologies,
            Frameworks = classificationEnvelope.Frameworks,
            Languages = classificationEnvelope.Languages,
        });

        return await context.Success();
    }

    private sealed class InventoryEnvelope
    {
        [JsonPropertyName("fileCount")] public int FileCount { get; set; }
        [JsonPropertyName("extensions")] public List<string> Extensions { get; set; } = [];
        [JsonPropertyName("directories")] public List<string> Directories { get; set; } = [];
        [JsonPropertyName("files")] public List<string> Files { get; set; } = [];
        [JsonPropertyName("technologies")] public List<string> Technologies { get; set; } = [];
    }

    private sealed class ClassificationEnvelope
    {
        [JsonPropertyName("technologies")] public List<string> Technologies { get; set; } = [];
        [JsonPropertyName("frameworks")] public List<string> Frameworks { get; set; } = [];
        [JsonPropertyName("languages")] public List<string> Languages { get; set; } = [];
    }
}
