using System.Text.Json;
using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Services.Prepare;
using ContextCompiler.Abstractions.Storage;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Prepare.Services;

internal sealed class ConfigurationRenderer(
    IConfigSerializer configSerializer,
    [FromKeyedServices(StoreKeys.Root)] IStore rootStore,
    ILogger<ConfigurationRenderer> logger) : IConfigurationRenderer
{
    private static readonly JsonSerializerOptions EnvelopeJsonOptions = new()
    {
        WriteIndented = true,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
    };

    public async Task RenderAsync(PreparePlan plan, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(plan);
        cancellationToken.ThrowIfCancellationRequested();

        await rootStore.Init();

        await RenderCtxcConfigAsync(plan, cancellationToken);
        await RenderModulesConfigAsync(plan, cancellationToken);
        await RenderSkillsConfigAsync(plan, cancellationToken);
    }

    private async Task RenderCtxcConfigAsync(PreparePlan plan, CancellationToken cancellationToken)
    {
        IRootConfigSection root = configSerializer.Deserialize("{}");
        root.AddFile(
            Includes: [.. plan.IncludePatterns],
            Excludes: [.. plan.ExcludePatterns],
            Subs: [],
            Tags: [],
            Options: null);

        root.AddView(
            Id: "default",
            title: "Project Context",
            selectTags: [],
            Excludes: [],
            order: [],
            renderers: ["yaml", "index.json"]);

        string json = configSerializer.Serialize(root);
        await WriteAsync("ctxc.config.json", json, cancellationToken);
    }

    private async Task RenderModulesConfigAsync(PreparePlan plan, CancellationToken cancellationToken)
    {
        Dictionary<string, string> packages = new([], StringComparer.OrdinalIgnoreCase);
        foreach (string pipeline in plan.RecommendedPipelines)
        {
            packages[pipeline] = "*";
        }

        ModulesEnvelope envelope = new()
        {
            SchemaVersion = 2,
            Modules = new ModulesSection
            {
                Mode = "Locked",
                InstallRoot = ".ctxc/modules",
                Offline = false,
                LockFile = ".ctxc/ctxc.modules.lock.json",
                RunModulesFile = ".ctxc/ctxc.modules.run.json",
                QuarantineRoot = ".ctxc/quarantine",
                ConfigurationModule = "ContextCompiler.Configuration.Json",
                Sources =
                [
                    new ModuleSourceEntry
                    {
                        Name = "nuget.org",
                        Url = "https://api.nuget.org/v3/index.json",
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
                Packages = packages,
            },
        };

        string json = JsonSerializer.Serialize(envelope, EnvelopeJsonOptions);
        await WriteAsync("ctxc.modules.config.json", json, cancellationToken);
    }

    private async Task RenderSkillsConfigAsync(PreparePlan plan, CancellationToken cancellationToken)
    {
        Dictionary<string, string> items = new([], StringComparer.OrdinalIgnoreCase);
        foreach (string skill in plan.RecommendedSkills)
        {
            items[skill] = "*";
        }

        SkillsEnvelope envelope = new()
        {
            SchemaVersion = 2,
            Skills = new SkillsSection
            {
                Mode = "Restore",
                Offline = false,
                LockFile = ".ctxc/ctxc.skills.lock.json",
                Items = items,
            },
        };

        string json = JsonSerializer.Serialize(envelope, EnvelopeJsonOptions);
        await WriteAsync("ctxc.skills.config.json", json, cancellationToken);
    }

    private async Task WriteAsync(string fileName, string content, CancellationToken cancellationToken)
    {
        IStoreResource resource = rootStore.Container.GetResource(fileName);
        await resource.WriteAllText(content, cancellationToken);
        logger.LogInformation("Wrote {Path}", resource.Uri.AbsolutePath);
    }

    private sealed class ModulesEnvelope
    {
        [JsonPropertyName("schemaVersion")] public int SchemaVersion { get; set; }
        [JsonPropertyName("modules")] public ModulesSection Modules { get; set; } = new();
    }

    private sealed class ModulesSection
    {
        [JsonPropertyName("mode")] public string Mode { get; set; } = "Locked";
        [JsonPropertyName("installRoot")] public string InstallRoot { get; set; } = ".ctxc/modules";
        [JsonPropertyName("offline")] public bool Offline { get; set; }
        [JsonPropertyName("lockFile")] public string LockFile { get; set; } = ".ctxc/ctxc.modules.lock.json";
        [JsonPropertyName("runModulesFile")] public string RunModulesFile { get; set; } = ".ctxc/ctxc.modules.run.json";
        [JsonPropertyName("quarantineRoot")] public string QuarantineRoot { get; set; } = ".ctxc/quarantine";
        [JsonPropertyName("configurationModule")] public string ConfigurationModule { get; set; } = "ContextCompiler.Configuration.Json";
        [JsonPropertyName("sources")] public List<ModuleSourceEntry> Sources { get; set; } = [];
        [JsonPropertyName("trust")] public TrustSection Trust { get; set; } = new();
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

    private sealed class SkillsEnvelope
    {
        [JsonPropertyName("schemaVersion")] public int SchemaVersion { get; set; }
        [JsonPropertyName("skills")] public SkillsSection Skills { get; set; } = new();
    }

    private sealed class SkillsSection
    {
        [JsonPropertyName("mode")] public string Mode { get; set; } = "Restore";
        [JsonPropertyName("offline")] public bool Offline { get; set; }
        [JsonPropertyName("lockFile")] public string LockFile { get; set; } = ".ctxc/ctxc.skills.lock.json";
        [JsonPropertyName("items")] public Dictionary<string, string> Items { get; set; } = [];
    }
}

