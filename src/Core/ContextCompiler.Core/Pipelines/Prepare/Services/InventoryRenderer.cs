using System.Text.Json;
using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Services.Prepare;
using ContextCompiler.Abstractions.Storage;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Prepare.Services;

internal sealed class InventoryRenderer(
    ILogger<InventoryRenderer> logger) : IInventoryRenderer
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
    };

    public async Task RenderAsync(IStore outputStore, ProjectInventory inventory, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(inventory);
        cancellationToken.ThrowIfCancellationRequested();

        await outputStore.Init();

        InventoryEnvelope envelope = new()
        {
            SchemaVersion = 1,
            FileCount = inventory.FileCount,
            Extensions = [.. inventory.Extensions],
            Directories = [.. inventory.Directories],
            Files = [.. inventory.Files],
            Technologies = [.. inventory.Technologies],
        };

        string json = JsonSerializer.Serialize(envelope, JsonOptions);
        IStoreResource resource = outputStore.Container.GetResource("inventory.json");
        await resource.WriteAllText(json, cancellationToken);
        logger.LogInformation("Wrote {Path}", resource.Uri.AbsolutePath);
    }

    private sealed class InventoryEnvelope
    {
        [JsonPropertyName("schemaVersion")] public int SchemaVersion { get; set; }
        [JsonPropertyName("fileCount")] public int FileCount { get; set; }
        [JsonPropertyName("extensions")] public List<string> Extensions { get; set; } = [];
        [JsonPropertyName("directories")] public List<string> Directories { get; set; } = [];
        [JsonPropertyName("files")] public List<string> Files { get; set; } = [];
        [JsonPropertyName("technologies")] public List<string> Technologies { get; set; } = [];
    }
}
