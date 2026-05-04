using System.Reflection;
using System.Text.Json;

using ContextCompiler.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Loader
{
    public class ModulesLoader(IModulesDiscoverer modulesDiscoverer,
                               IModuleRegistryBuilder moduleRegistryBuilder,
                               IModulesLoadConfigProvider configProvider,
                               IWorkingFolder workingFolder,
                               ILogger<ModulesLoader> logger) : IModulesLoader
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true
        };

        public async Task<IEnumerable<Type>> LoadFromFolder(string path, IServiceCollection services, CancellationToken cancellationToken)
        {
            logger.LogInformation("Starting module discovery in folder: {Path}", path);

            //IEnumerable<Type> moduleTypes = await modulesDiscoverer.Discover(path, cancellationToken);

            //logger.LogInformation("Discovered {Count} module(s) in folder: {Path}", moduleTypes.Count(), path);

            //moduleRegistryBuilder.RegisterModuleServices(services, moduleTypes);

            // Load additional modules from lock file (only configured packages, not their dependencies)
            return await LoadAdditionalModulesAsync(services, path, cancellationToken);
        }

        private async Task<IEnumerable<Type>> LoadAdditionalModulesAsync(IServiceCollection services, string path, CancellationToken cancellationToken)
        {
            List<Type> modulesType = [];
            try
            {
                ModuleLockFile lockFile = LoadLockFile();
                string installRoot = path;
                IEnumerable<string> configuredPackages = configProvider.Current.Packages.Select(x => x.Key.Split('@').First());
                IEnumerable<string> runModules = LoadRunModulesFile().Keys.Select(x => x.Split('@').First());

                HashSet<string> processedModules = [];

                foreach (ModuleLockFile.LockedModule package in lockFile.Packages)
                {
                    // Only load packages that are explicitly configured as modules
                    // Skip dependencies - .NET runtime will resolve them automatically when needed
                    if (!configuredPackages.Any(x => x == package.Id) && !runModules.Any(x => x == package.Id))
                    {
                        logger.LogDebug("Skipping {PackageId} - not a configured module (dependency will be loaded by runtime if needed)", package.Id);
                        continue;
                    }

                    if (processedModules.Contains(package.Id))
                    {
                        continue;
                    }

                    _ = processedModules.Add(package.Id);

                    string? modulePath = FindInstalledModule(installRoot, package.Id, package.Version, package.Checksum);

                    if (modulePath != null)
                    {
                        logger.LogInformation("Loading module {ModuleId} {Version} from {Path}", package.Id, package.Version, modulePath);

                        IEnumerable<Type> discovered = await modulesDiscoverer.Discover(modulePath, package.Id, cancellationToken);

                        logger.LogInformation("Discovered {Count} module type(s) in {ModuleId}", discovered.Count(), package.Id);

                        moduleRegistryBuilder.RegisterModuleServices(services, discovered);

                        modulesType.AddRange(discovered);
                    }
                    else
                    {
                        logger.LogWarning("Module {ModuleId} {Version} not found in install root", package.Id, package.Version);
                    }
                }

                await moduleRegistryBuilder.RunDelayedFeatureDependencyInjection(services);

                logger.LogInformation("Loaded {Count} additional modules from lock file", processedModules.Count);
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "Could not load additional modules from lock file. This may be expected if no lock file exists yet.");
            }

            return modulesType;
        }

        private static string? FindInstalledModule(string installRoot, string packageId, ModuleLockFile.Version version, string checksum)
        {
            string hashDir = checksum.Replace("/", "_").Replace("+", "-");
            //TODO : Version a gérer correctement (actuellement on suppose que la version min est la version exacte)
            string modulePath = Path.Combine(installRoot, packageId, version.Min, hashDir);

            return Directory.Exists(modulePath) ? modulePath : null;
        }

        public Task LoadFromAssemblies(Assembly[] assemblies, IServiceCollection services)
        {
            logger.LogInformation("Starting module discovery in assemblies: {Assemblies}", string.Join(", ", assemblies.Select(a => a.GetName().Name)));

            foreach (Assembly assembly in assemblies)
            {
                moduleRegistryBuilder.RegisterModuleServices(services, assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract));
            }

            return Task.CompletedTask;
        }

        public bool Clean()
        {
            try
            {
                string path = Path.Combine(workingFolder.Path, configProvider.Current.LockFile);
                if (File.Exists(path))
                {
                    File.Delete(path);
                    logger.LogInformation("Lock file deleted: {Path}", path);
                }
                else
                {
                    logger.LogInformation("No lock file to delete at: {Path}", path);
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while cleaning modules lock file");
                return false;
            }
        }

        public ModuleLockFile LoadLockFile()
        {
            string path = Path.Combine(workingFolder.Path, configProvider.Current.LockFile);
            return !File.Exists(path)
                ? throw new InvalidOperationException($"Lock file not found: {path}")
                : JsonSerializer.Deserialize<ModuleLockFile>(File.ReadAllText(path), JsonOptions)!;
        }
        public void SaveLockFile(ModuleLockFile lockFile)
        {
            string path = Path.Combine(workingFolder.Path, configProvider.Current.LockFile);
            _ = Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            File.WriteAllText(path, JsonSerializer.Serialize(lockFile, JsonOptions));
        }

        public void SaveRunModules(IReadOnlyDictionary<string, string> runModules)
        {
            string path = Path.Combine(workingFolder.Path, configProvider.Current.RunModulesFile);
            _ = Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            File.WriteAllText(path, JsonSerializer.Serialize(runModules, JsonOptions));

        }

        private IReadOnlyDictionary<string, string> LoadRunModulesFile()
        {
            string path = Path.Combine(workingFolder.Path, configProvider.Current.RunModulesFile);
            return !File.Exists(path)
                ? throw new InvalidOperationException($"Run modules file not found: {path}")
                : JsonSerializer.Deserialize<IReadOnlyDictionary<string, string>>(File.ReadAllText(path), JsonOptions)!;
        }
    }
}
