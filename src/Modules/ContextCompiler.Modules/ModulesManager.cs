using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace ContextCompiler.Modules;

public sealed class ModulesManager(ICtxcWorkingFolder ctxcWorkingFolder,
                                  IModulesLoadConfigProvider cfg,
                                  IModulesToRestoreProvider modulesToRestoreProvider,
                                  IModulesLoader modulesLoader,
                                  IServiceProvider serviceProvider,
                                  IConfigurationSchemasAggregator configurationSchemasAggregator,
                                  ISchemaBuilder schemaBuilder,
                                  IModuleRestoreRequestBuilder moduleRestoreRequestBuilder,
                                  ITrustPolicy policy,
                                  ISourcesProvider sourcesProvider,
                                  ILogger<ModulesManager> logger) : IModulesManager
{

    public Task<IEnumerable<string>> LoadableModules()
    {
        IEnumerable<IModuleRestoreRequest> restoreRequests = modulesToRestoreProvider.ModulesToRestore();
        return Task.FromResult(restoreRequests.Select(r => r.PackageId.Id));
    }

    public async Task<ModuleLockFile> RestoreAndLockAsync(CancellationToken ct)
    {
        ModuleLockFile lockFile = new() { FormatVersion = 1, GeneratedAt = DateTime.UnixEpoch, Packages = [] };
        List<string> moduleSchemaPaths = [];
        IEnumerable<string> mainSchemaPaths = [];

        Dictionary<string, string> toRestore = cfg.Current.Packages;

        IEnumerable<IConfigurationSchemasDiscoverer> configurationSchemasDiscoverers = serviceProvider.GetServices<IConfigurationSchemasDiscoverer>();

        //List<IModuleRestoreRequest> restoreRequests = [];
        //foreach (KeyValuePair<string, string> pkg in toRestore)
        //{
        //    logger.LogInformation("Module {ModuleId} version {Version} is marked for restore", pkg, toRestore[pkg]);
        //    IEnumerable<IModuleRestoreVersionParser> moduleRestoreVersionParsers = serviceProvider.GetServices<IModuleRestoreVersionParser>();
        //    IModuleRestoreVersion? moduleRestoreVersion = null;
        //    foreach (IModuleRestoreVersionParser moduleRestoreVersionParser in moduleRestoreVersionParsers)
        //    {
        //        if (moduleRestoreVersionParser.TryParse(pkg.Value, out moduleRestoreVersion))
        //        {
        //            break;
        //        }
        //    }

        //    restoreRequests.Add(moduleRestoreRequestBuilder.InitNew().WithPackageId(pkg.Key).WithVersion(moduleRestoreVersion));
        //}

        IEnumerable<IModuleRestoreRequest> restoreRequests = modulesToRestoreProvider.ModulesToRestore();

        foreach (IModuleRestoreRequest req in restoreRequests)
        {
            try
            {
                if (!sourcesProvider.Exists(req.PackageId.Source.Id))
                {
                    throw new InvalidOperationException("Unknown source {req.Source.Id)}");
                }

                ISource source = sourcesProvider.GetById(req.PackageId.Source.Id);
                IModulesStore? store = serviceProvider.GetKeyedService<IModulesStore>(source.Provider)
                                       ?? throw new InvalidOperationException($"No module store found for provider {source.Provider}");

                IModuleRestoreRequestResult restoreResult = await store.RestoreAsync(req, ct);

                if (restoreResult.Success)
                {
                    IEnumerable<string> currentModuleSchemaPaths = [];
                    foreach (IConfigurationSchemasDiscoverer discoverer in configurationSchemasDiscoverers)
                    {
                        currentModuleSchemaPaths = [.. currentModuleSchemaPaths, .. await discoverer.Discover(restoreResult.RestoredPath)];
                    }


                    if (req.PackageId.Id == cfg.Current.ConfigurationModule)
                    {
                        mainSchemaPaths = currentModuleSchemaPaths;
                        logger.LogInformation("Discovered {Count} configuration schemas for main configuration module {ModuleId} from {ExtractedRoot}", mainSchemaPaths.Count(), req.PackageId.Id, req.ExtractPath);
                    }
                    else
                    {
                        moduleSchemaPaths = [.. moduleSchemaPaths, .. currentModuleSchemaPaths];
                        logger.LogInformation("Discovered {Count} configuration schemas for module {ModuleId} from {ExtractedRoot}", currentModuleSchemaPaths.Count(), req.PackageId.Id, req.ExtractPath);
                    }

                    lockFile.Packages.Add(new ModuleLockFile.LockedModule
                    {
                        Id = req.PackageId.Id,
                        Version = new()
                        {
                            Raw = req.Version.Raw,
                            Min = req.Version.Min,
                            Max = req.Version.Max,
                            MinBoundOperator = Enum.Parse<ModuleLockFile.BoundOperator>(req.Version.MinBoundOperator.ToString()),
                            MaxBoundOperator = Enum.Parse<ModuleLockFile.BoundOperator>(req.Version.MaxBoundOperator.ToString()),
                        },
                        Source = req.PackageId.Source.ToString() ?? "",
                        Checksum = restoreResult.Metadatas.Checksum,
                        Files = restoreResult.Metadatas.Files.ToList() ?? [],
                        Dependencies = restoreResult.Metadatas.Dependencies.Select(x => x.ToDependencyInfo()).ToList() ?? [],
                        Signature = restoreResult.Metadatas.Signature.ToSignatureInfo(),
                    });
                }
            }
            catch (Exception ex)
            {
                try
                {
                    string cached = Path.Combine(Path.GetFullPath(cfg.Current.InstallRoot), "_nupkg", req.PackageId.Id, req.Version.ToString() ?? "", $"{req.PackageId.Id}.{req.Version}.nupkg");
                    if (File.Exists(cached))
                    {
                        _ = Quarantine.MoveToQuarantine(cfg.Current.QuarantineRoot, req.PackageId.Id, req.Version.ToString() ?? "", cached, ex.ToString());
                    }
                }
                catch { }
                throw;
            }
        }

        if (!mainSchemaPaths.Any())
        {
            foreach (string mainSchemaPath in mainSchemaPaths)
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
                File.WriteAllText(Path.Combine(schemasPath, Path.GetFileName(aggregatedSchema.Path)), aggregatedSchema.Content);
            }
        }
        return lockFile;
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
            ModuleLockFile lf = modulesLoader.LoadLockFile();
            foreach (ModuleLockFile.LockedModule p in lf.Packages)
            {
                string shaDir = p.Checksum.Replace("/", "_").Replace("+", "-");
                _ = keep.Add((p.Id, p.Version.Raw, shaDir));
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
