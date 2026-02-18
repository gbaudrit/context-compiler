using System.Text.Json;

using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Plugins.Abstractions;
using ContextCompiler.Plugins.Abstractions.Configuration;

using Microsoft.Extensions.Logging;
namespace ContextCompiler.Plugins.NuGet;

public sealed class PluginManager(ICtxcWorkingFolder ctxcWorkingFolder,
                                  IPluginsLoadConfigProvider cfg,
                                  INuGetPluginStore store,
                                  IServiceProvider serviceProvider,
                                  IConfigurationSchemasAggregator configurationSchemasAggregator,
                                  ISchemaBuilder schemaBuilder,
                                  ILogger<PluginManager> logger) : IPluginManager
{
    private readonly TrustPolicy _policy = new(cfg);

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true
    };

    public async Task<PluginLockFile> RestoreAndLockAsync(CancellationToken ct)
    {
        PluginLockFile lockFile = new() { FormatVersion = 1, GeneratedAt = DateTime.UnixEpoch, Packages = [] };
        List<string> pluginSchemaPaths = [];
        foreach (PluginPackageRequest req in cfg.Current.Packages)
        {
            try
            {
                string nupkg = await store.RestoreAsync(req, ct);
                string sha = store.ComputeAndVerifySha(nupkg, req.Sha256);
                (string? authors, string? repoUrl, List<PluginLockFile.DependencyInfo>? deps, List<string>? files) = store.ReadNuspecAndDeps(nupkg);
                _policy.ValidateNuspec(authors, repoUrl);
                (bool isSigned, string? note) = store.CheckSignedBestEffort(nupkg);
                _policy.ValidateSignature(isSigned, note);
                string extractedRoot = store.ExtractToImmutableCache(nupkg, req.Id, req.Version, sha);

                IEnumerable<string> currentPluginSchemaPaths = Directory.GetFiles(extractedRoot, "ctxc.config.schema.*", SearchOption.AllDirectories);
                foreach (string candidate in currentPluginSchemaPaths)
                {
                    if (File.Exists(candidate))
                    {
                        pluginSchemaPaths.Add(candidate);
                    }
                }
                lockFile.Packages.Add(new PluginLockFile.LockedPlugin
                {
                    Id = req.Id,
                    Version = req.Version,
                    Source = req.Source,
                    Sha256 = sha,
                    Files = files,
                    Dependencies = deps,
                    Nuspec = new PluginLockFile.NuspecInfo { Authors = authors, RepositoryUrl = repoUrl },
                    Signature = new PluginLockFile.SignatureInfo { Required = cfg.Current.Trust.RequireSignedPackages, IsSigned = isSigned, Note = note }
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

        IAggregatedSchema aggregatedSchema = await configurationSchemasAggregator.AggregateSchemas(schema1, [.. pluginSchemaPaths.Select(p => schemaBuilder.InitNew()
                                          .WithName(Path.GetFileNameWithoutExtension(p))
                                          .WithContent(File.ReadAllText(p))
                                          .WithPath(p)
                                          .Build())]);

        //await TryWriteAggregatedSchema(pluginSchemaPaths);
        return lockFile;
    }

    public PluginLockFile LoadLockFile()
    {
        string path = Path.GetFullPath(cfg.Current.LockFile);
        return !File.Exists(path)
            ? throw new InvalidOperationException($"Lock file not found: {path}")
            : JsonSerializer.Deserialize<PluginLockFile>(File.ReadAllText(path), JsonOptions)!;
    }
    public void SaveLockFile(PluginLockFile lockFile)
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
            PluginLockFile lf = LoadLockFile();
            foreach (PluginLockFile.LockedPlugin p in lf.Packages)
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
