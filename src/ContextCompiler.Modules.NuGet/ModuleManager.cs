using System.Text.Json;

using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;

using Microsoft.Extensions.Logging;
namespace ContextCompiler.Modules.NuGet;

public sealed class ModuleManager(ICtxcWorkingFolder ctxcWorkingFolder,
                                  IModulesLoadConfigProvider cfg,
                                  INuGetModuleStore store,
                                  IServiceProvider serviceProvider,
                                  IConfigurationSchemasAggregator configurationSchemasAggregator,
                                  ISchemaBuilder schemaBuilder,
                                  ILogger<ModuleManager> logger) : IModulesManager
{
    private readonly TrustPolicy _policy = new(cfg);

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true
    };

    public async Task<ModuleLockFile> RestoreAndLockAsync(CancellationToken ct)
    {
        ModuleLockFile lockFile = new() { FormatVersion = 1, GeneratedAt = DateTime.UnixEpoch, Packages = [] };
        List<string> moduleSchemaPaths = [];
        string mainSchemaPath = "";

        List<ModulePackageRequest> toRestore = cfg.Current.Packages;

        foreach (ModulePackageRequest req in cfg.Current.Packages)
        {
            try
            {
                string nupkg = await store.RestoreAsync(req, ct);
                string sha = store.ComputeAndVerifySha(nupkg, req.Sha256);
                (string? authors, string? repoUrl, List<ModuleLockFile.DependencyInfo>? deps, List<string>? files) = store.ReadNuspecAndDeps(nupkg);
                _policy.ValidateNuspec(authors, repoUrl);
                (bool isSigned, string? note) = store.CheckSignedBestEffort(nupkg);
                _policy.ValidateSignature(isSigned, note);
                string extractedRoot = store.ExtractToImmutableCache(nupkg, req.Id, req.Version, sha);

                if (req.Id == cfg.Current.ConfigurationModule)
                {
                    string candidateMainSchemaPath = Directory.GetFiles(extractedRoot, "ctxc.config.schema.*", SearchOption.AllDirectories).FirstOrDefault() ?? "";
                    if (File.Exists(candidateMainSchemaPath))
                    {
                        mainSchemaPath = candidateMainSchemaPath;
                        logger.LogInformation("Configuration module {Module} main schema found at {Path}", req.Id, candidateMainSchemaPath);
                    }
                    else
                    {
                        logger.LogWarning("Configuration module {Module} does not contain a main schema at expected path {Path}", req.Id, candidateMainSchemaPath);
                    }
                }
                else
                {


                    IEnumerable<string> currentModuleSchemaPaths = Directory.GetFiles(extractedRoot, "ctxc.config.schema.*", SearchOption.AllDirectories);
                    foreach (string candidate in currentModuleSchemaPaths)
                    {
                        if (File.Exists(candidate))
                        {
                            moduleSchemaPaths.Add(candidate);
                        }
                    }
                }
                lockFile.Packages.Add(new ModuleLockFile.LockedModule
                {
                    Id = req.Id,
                    Version = req.Version,
                    Source = req.Source,
                    Sha256 = sha,
                    Files = files,
                    Dependencies = deps,
                    Nuspec = new ModuleLockFile.NuspecInfo { Authors = authors, RepositoryUrl = repoUrl },
                    Signature = new ModuleLockFile.SignatureInfo { Required = cfg.Current.Trust.RequireSignedPackages, IsSigned = isSigned, Note = note }
                });
            }
            catch (Exception ex)
            {
                try
                {
                    string cached = Path.Combine(Path.GetFullPath(cfg.Current.InstallRoot), "_nupkg", req.Id, req.Version, $"{req.Id}.{req.Version}.nupkg");
                    if (File.Exists(cached))
                    {
                        _ = Quarantine.MoveToQuarantine(cfg.Current.QuarantineRoot, req.Id, req.Version, cached, ex.ToString());
                    }
                }
                catch { }
                throw;
            }
        }

        if (!string.IsNullOrEmpty(mainSchemaPath))
        {
            ISchema mainSchema = schemaBuilder.InitNew()
                                          .WithName(Path.GetFileNameWithoutExtension(mainSchemaPath))
                                          .WithContent(File.ReadAllText(mainSchemaPath))
                                          .WithPath(mainSchemaPath)
                                          .Build();

            IAggregatedSchema aggregatedSchema = await configurationSchemasAggregator.AggregateSchemas(mainSchema, [.. moduleSchemaPaths.Select(p => schemaBuilder.InitNew()
                                          .WithName(Path.GetFileNameWithoutExtension(p))
                                          .WithContent(File.ReadAllText(p))
                                          .WithPath(p)
                                          .Build())]);

            string schemasPath = Path.Combine(ctxcWorkingFolder.Path, "schemas");
            if (!Directory.Exists(schemasPath))
            {
                _ = Directory.CreateDirectory(schemasPath);
            }
            File.WriteAllText(Path.Combine(schemasPath, "ctxc.config.schema.json"), aggregatedSchema.Content);
        }
        return lockFile;
    }

    public ModuleLockFile LoadLockFile()
    {
        string path = Path.GetFullPath(cfg.Current.LockFile);
        return !File.Exists(path)
            ? throw new InvalidOperationException($"Lock file not found: {path}")
            : JsonSerializer.Deserialize<ModuleLockFile>(File.ReadAllText(path), JsonOptions)!;
    }
    public void SaveLockFile(ModuleLockFile lockFile)
    {
        string path = Path.GetFullPath(cfg.Current.LockFile);
        _ = Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, JsonSerializer.Serialize(lockFile, JsonOptions));
    }
    public IEnumerable<(string id, string version, string shaDir)> ListInstalled()
    {
        string root = Path.GetFullPath(cfg.Current.InstallRoot);
        if (!Directory.Exists(root))
        {
            yield break;
        }

        foreach (string idDir in Directory.GetDirectories(root))
        {
            string id = Path.GetFileName(idDir);
            if (id.StartsWith("_", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            foreach (string verDir in Directory.GetDirectories(idDir))
            {
                string ver = Path.GetFileName(verDir);
                foreach (string shaDir in Directory.GetDirectories(verDir))
                {
                    yield return (id, ver, Path.GetFileName(shaDir));
                }
            }
        }
    }
    public void PurgeCache(bool keepLockfilePinned = true)
    {
        string installRoot = Path.GetFullPath(cfg.Current.InstallRoot);
        if (!Directory.Exists(installRoot))
        {
            return;
        }

        HashSet<(string id, string ver, string sha)> keep = [];
        if (keepLockfilePinned && File.Exists(Path.GetFullPath(cfg.Current.LockFile)))
        {
            ModuleLockFile lf = LoadLockFile();
            foreach (ModuleLockFile.LockedModule p in lf.Packages)
            {
                string shaDir = p.Sha256.Replace("/", "_").Replace("+", "-");
                _ = keep.Add((p.Id, p.Version, shaDir));
            }
        }
        foreach (string idDir in Directory.GetDirectories(installRoot))
        {
            string id = Path.GetFileName(idDir);
            if (id.StartsWith("_", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            foreach (string verDir in Directory.GetDirectories(idDir))
            {
                string ver = Path.GetFileName(verDir);
                foreach (string shaDir in Directory.GetDirectories(verDir))
                {
                    string sha = Path.GetFileName(shaDir);
                    if (keep.Contains((id, ver, sha)))
                    {
                        continue;
                    }

                    Directory.Delete(shaDir, true);
                }
            }
        }
    }
}
