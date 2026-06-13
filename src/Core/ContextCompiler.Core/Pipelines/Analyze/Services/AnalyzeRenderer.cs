using System.Text.Json;
using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Models.Analyze;
using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Services.Analyze;
using ContextCompiler.Abstractions.Storage;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Analyze.Services;

internal sealed class AnalyzeRenderer(ILogger<AnalyzeRenderer> logger) : IAnalyzeRenderer
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
    };

    public async Task RenderAsync(
        IStore rootStore,
        IStore prepareStore,
        ProjectInventory inventory,
        ProjectClassification classification,
        AnalyzePlan plan,
        CancellationToken cancellationToken)
    {
        await rootStore.Init();
        await prepareStore.Init();

        await prepareStore.Container.GetResource("inventory.json")
            .WriteAllText(JsonSerializer.Serialize(ToInventoryEnvelope(inventory), JsonOptions), cancellationToken);

        await prepareStore.Container.GetResource("classification.json")
            .WriteAllText(JsonSerializer.Serialize(ToClassificationEnvelope(classification), JsonOptions), cancellationToken);

        await prepareStore.Container.GetResource("analyze.plan.json")
            .WriteAllText(JsonSerializer.Serialize(ToAnalyzePlanEnvelope(plan), JsonOptions), cancellationToken);

        await RenderModulesConfigAsync(rootStore, plan, cancellationToken);
        logger.LogInformation("Analyze artifacts written");
    }

    private static async Task RenderModulesConfigAsync(IStore rootStore, AnalyzePlan plan, CancellationToken cancellationToken)
    {
        ModulesEnvelope envelope = new()
        {
            SchemaVersion = 1,
            Modules = new ModulesSection
            {
                Sources =
                [
                    new ModuleSourceEntry
                    {
                        Name = "default",
                        Url = "https://api.nuget.org/v3/index.json",
                        Trusted = true,
                        Provider = "nuget",
                    },
                    new ModuleSourceEntry
                    {
                        Name = "local",
                        Url = "local-packages",
                        Trusted = true,
                        Provider = "nuget",
                    },
                ],
                Trust = new TrustSection
                {
                    RequireTrustedSource = true,
                    RequireSignedPackages = false,
                    AllowedPackageIds = ["ContextCompiler.*"],
                    BlockedPackageIds = [],
                    AllowedAuthors = [],
                    AllowedRepositoryPrefixes = [],
                },
                Prepare = new ModuleScopeSection
                {
                    Packages = new Dictionary<string, string>(plan.RecommendedPrepareModules, StringComparer.OrdinalIgnoreCase),
                },
                Compile = new ModuleScopeSection
                {
                    Packages = new Dictionary<string, string>(plan.RecommendedCompileModules, StringComparer.OrdinalIgnoreCase),
                },
            },
        };

        string json = JsonSerializer.Serialize(envelope, JsonOptions);
        await rootStore.Container.GetResource("ctxc.modules.config.json").WriteAllText(json, cancellationToken);
    }

    private static InventoryEnvelope ToInventoryEnvelope(ProjectInventory inventory)
    {
        return new InventoryEnvelope
        {
            SchemaVersion = 1,
            FileCount = inventory.FileCount,
            Extensions = [.. inventory.Extensions],
            Directories = [.. inventory.Directories],
            Files = [.. inventory.Files],
            Technologies = [.. inventory.Technologies],
        };
    }

    private static ClassificationEnvelope ToClassificationEnvelope(ProjectClassification classification)
    {
        return new ClassificationEnvelope
        {
            SchemaVersion = 1,
            Technologies = [.. classification.Technologies],
            Frameworks = [.. classification.Frameworks],
            Languages = [.. classification.Languages],
        };
    }

    private static AnalyzePlanEnvelope ToAnalyzePlanEnvelope(AnalyzePlan plan)
    {
        return new AnalyzePlanEnvelope
        {
            SchemaVersion = 1,
            Technologies = [.. plan.Technologies],
            RecommendedPrepareModules = new Dictionary<string, string>(plan.RecommendedPrepareModules, StringComparer.OrdinalIgnoreCase),
            RecommendedCompileModules = new Dictionary<string, string>(plan.RecommendedCompileModules, StringComparer.OrdinalIgnoreCase),
            Diagnostics = [.. plan.Diagnostics],
        };
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

    private sealed class ClassificationEnvelope
    {
        [JsonPropertyName("schemaVersion")] public int SchemaVersion { get; set; }
        [JsonPropertyName("technologies")] public List<string> Technologies { get; set; } = [];
        [JsonPropertyName("frameworks")] public List<string> Frameworks { get; set; } = [];
        [JsonPropertyName("languages")] public List<string> Languages { get; set; } = [];
    }

    private sealed class AnalyzePlanEnvelope
    {
        [JsonPropertyName("schemaVersion")] public int SchemaVersion { get; set; }
        [JsonPropertyName("technologies")] public List<string> Technologies { get; set; } = [];
        [JsonPropertyName("recommendedPrepareModules")] public Dictionary<string, string> RecommendedPrepareModules { get; set; } = [];
        [JsonPropertyName("recommendedCompileModules")] public Dictionary<string, string> RecommendedCompileModules { get; set; } = [];
        [JsonPropertyName("diagnostics")] public List<string> Diagnostics { get; set; } = [];
    }

    private sealed class ModulesEnvelope
    {
        [JsonPropertyName("schemaVersion")] public int SchemaVersion { get; set; }
        [JsonPropertyName("modules")] public ModulesSection Modules { get; set; } = new();
    }

    private sealed class ModulesSection
    {
        [JsonPropertyName("sources")] public List<ModuleSourceEntry> Sources { get; set; } = [];
        [JsonPropertyName("trust")] public TrustSection Trust { get; set; } = new();
        [JsonPropertyName("prepare")] public ModuleScopeSection Prepare { get; set; } = new();
        [JsonPropertyName("compile")] public ModuleScopeSection Compile { get; set; } = new();
    }

    private sealed class ModuleScopeSection
    {
        [JsonPropertyName("packages")] public Dictionary<string, string> Packages { get; set; } = [];
    }

    private sealed class ModuleSourceEntry
    {
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
        [JsonPropertyName("url")] public string Url { get; set; } = string.Empty;
        [JsonPropertyName("trusted")] public bool Trusted { get; set; }
        [JsonPropertyName("provider")] public string Provider { get; set; } = "nuget";
    }

    private sealed class TrustSection
    {
        [JsonPropertyName("requireTrustedSource")] public bool RequireTrustedSource { get; set; } = true;
        [JsonPropertyName("requireSignedPackages")] public bool RequireSignedPackages { get; set; }
        [JsonPropertyName("allowedPackageIds")] public List<string> AllowedPackageIds { get; set; } = [];
        [JsonPropertyName("blockedPackageIds")] public List<string> BlockedPackageIds { get; set; } = [];
        [JsonPropertyName("allowedAuthors")] public List<string> AllowedAuthors { get; set; } = [];
        [JsonPropertyName("allowedRepositoryPrefixes")] public List<string> AllowedRepositoryPrefixes { get; set; } = [];
    }
}
