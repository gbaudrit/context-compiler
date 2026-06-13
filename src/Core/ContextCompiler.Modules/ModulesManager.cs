using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
namespace ContextCompiler.Modules;

public sealed class ModulesManager(ICtxcWorkingFolder ctxcWorkingFolder,
                                  IOptions<ModulesConfig> cfgOptions,
                                  IDeclaredModulesProvider declaredModulesProvider,
                                  IModulesLoader modulesLoader,
                                  [FromKeyedServices(StoreKeys.Root)] IStore rootStore,
                                  IServiceProvider serviceProvider,
                                  IConfigurationSchemasAggregator configurationSchemasAggregator,
                                  ISchemaBuilder schemaBuilder,
                                  IDeclaredModuleBuilder DeclaredModuleBuilder,
                                  ITrustPolicy policy,
                                  IModulesSourcesProvider sourcesProvider,
                                  ILogger<ModulesManager> logger) : IModulesManager
{
    private ModulesConfig Cfg => cfgOptions.Value;

    public Task<IEnumerable<string>> LoadableModules()
    {
        IEnumerable<IDeclaredModule> restoreRequests = declaredModulesProvider.GetDeclaredModules();
        return Task.FromResult(restoreRequests.Select(r => r.PackageId.Id));
    }

    public async Task<ModuleLockFile> RestoreAndLockAsync(bool force, CancellationToken ct)
    {
        ModuleLockFile lockFile = new() { FormatVersion = 1, GeneratedAt = DateTime.UnixEpoch, Packages = [] };
        List<string> moduleSchemaPaths = [];
        IEnumerable<string> mainSchemaPaths = [];

        Dictionary<string, string> toRestore = Cfg.GetPackagesForScope(Cfg.ActiveScope);

        IEnumerable<IConfigurationSchemasDiscoverer> configurationSchemasDiscoverers = serviceProvider.GetServices<IConfigurationSchemasDiscoverer>();

        //List<IDeclaredModule> restoreRequests = [];
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

        //    restoreRequests.Add(DeclaredModuleBuilder.InitNew().WithPackageId(pkg.Key).WithVersion(moduleRestoreVersion));
        //}

        IEnumerable<IDeclaredModule> restoreRequests = declaredModulesProvider.GetDeclaredModules();

        foreach (IDeclaredModule req in restoreRequests)
        {
            try
            {
                IModuleRestoreRequestResult? restoreResult = null;
                if (req.PackageId.Source.Id == ModuleSourceIds.All)
                {
                    foreach (IModuleSource source in sourcesProvider.GetAllOrdered())
                    {
                        IModulesStore? store = serviceProvider.GetKeyedService<IModulesStore>(source.Provider)
                                               ?? throw new InvalidOperationException($"No module store found for provider {source.Provider}");
                        try
                        {
                            restoreResult = await store.RestoreAsync(req, source, force, ct);
                            if (restoreResult.Success)
                            {
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            logger.LogWarning(ex, "Failed to restore module {ModuleId} from source {SourceId}", req.PackageId.Id, source.Id);

                        }
                    }
                }
                else
                {
                    if (!sourcesProvider.Exists(req.PackageId.Source.Id))
                    {
                        throw new InvalidOperationException("Unknown source {req.Source.Id)}");
                    }

                    IModuleSource source = sourcesProvider.GetById(req.PackageId.Source.Id);
                    IModulesStore? store = serviceProvider.GetKeyedService<IModulesStore>(source.Provider)
                                           ?? throw new InvalidOperationException($"No module store found for provider {source.Provider}");

                    restoreResult = await store.RestoreAsync(req, source, force, ct);
                }


                if (restoreResult != null && restoreResult.Success)
                {
                    IEnumerable<string> currentModuleSchemaPaths = [];
                    foreach (IConfigurationSchemasDiscoverer discoverer in configurationSchemasDiscoverers)
                    {
                        currentModuleSchemaPaths = [.. currentModuleSchemaPaths, .. await discoverer.Discover(restoreResult.RestoredPath)];
                    }


                    if (req.PackageId.Id == Cfg.ConfigurationModule)
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
                            Raw = string.IsNullOrWhiteSpace(restoreResult.ResolvedVersion) ? req.Version.Raw : restoreResult.ResolvedVersion,
                            Min = string.IsNullOrWhiteSpace(restoreResult.ResolvedVersion) ? req.Version.Min : restoreResult.ResolvedVersion,
                            Max = string.IsNullOrWhiteSpace(restoreResult.ResolvedVersion) ? req.Version.Max : restoreResult.ResolvedVersion,
                            MinBoundOperator = string.IsNullOrWhiteSpace(restoreResult.ResolvedVersion)
                                ? Enum.Parse<ModuleLockFile.BoundOperator>(req.Version.MinBoundOperator.ToString())
                                : ModuleLockFile.BoundOperator.Exactly,
                            MaxBoundOperator = string.IsNullOrWhiteSpace(restoreResult.ResolvedVersion)
                                ? Enum.Parse<ModuleLockFile.BoundOperator>(req.Version.MaxBoundOperator.ToString())
                                : ModuleLockFile.BoundOperator.Exactly,
                        },
                        Source = req.PackageId.Source.Id,
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
                    string cached = Path.Combine(ResolveRootPath(Cfg.InstallRoot), "_nupkg", req.PackageId.Id, req.Version.ToString() ?? "", $"{req.PackageId.Id}.{req.Version}.nupkg");
                    if (File.Exists(cached))
                    {
                        _ = Quarantine.MoveToQuarantine(Cfg.QuarantineRoot, req.PackageId.Id, req.Version.ToString() ?? "", cached, ex.ToString());
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
        string root = ResolveRootPath(Cfg.InstallRoot);
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
        string installRoot = ResolveRootPath(Cfg.InstallRoot);
        if (!Directory.Exists(installRoot))
        {
            return;
        }

        HashSet<(string id, string ver, string sha)> keep = [];
        if (keepLockfilePinned && File.Exists(ResolveRootPath(Cfg.LockFile)))
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

    private string ResolveRootPath(string path)
    {
        return Path.IsPathRooted(path)
            ? path
            : rootStore.Container.GetResource(path).Uri.AbsolutePath;
    }
}
