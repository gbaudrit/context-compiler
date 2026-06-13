using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContextCompiler.Modules
{
    internal sealed class DeclaredModulesProvider(IOptions<ModulesConfig> cfgOptions,
                                            IDeclaredModuleBuilder DeclaredModuleBuilder,
                                            IModuleVersionOverrideResolver versionOverrideResolver,
                                            [FromKeyedServices(StoreKeys.Modules)] IStore modulesStore,
                                            IServiceProvider serviceProvider,
                                            ILogger<DeclaredModulesProvider> logger) : IDeclaredModulesProvider
    {
        private ModulesConfig Cfg => cfgOptions.Value;

        public IEnumerable<IDeclaredModule> GetDeclaredModules()
        {
            IList<IDeclaredModule> moduleRestoreRequests = [];

            foreach (KeyValuePair<string, string> pkg in Cfg.GetPackagesForScope(Cfg.ActiveScope))
            {
                if (string.IsNullOrWhiteSpace(pkg.Key))
                {
                    throw new InvalidOperationException("Package ID cannot be null or whitespace.");
                }
                if (string.IsNullOrWhiteSpace(pkg.Value))
                {
                    throw new InvalidOperationException($"Version for package {pkg.Key} cannot be null or whitespace.");
                }

                IModuleRestoreVersion? version = null;
                IModuleRestoreId? packageId = null;
                IEnumerable<IModuleRestorePackageIdParser> packageIdParsers = serviceProvider.GetServices<IModuleRestorePackageIdParser>();
                foreach (IModuleRestorePackageIdParser parser in packageIdParsers)
                {
                    if (parser.TryParse(pkg.Key, out packageId))
                    {
                        break;
                    }
                }

                if (packageId == null)
                {
                    throw new InvalidOperationException($"Unable to parse package ID from package ID '{pkg.Key}'.");
                }

                string effectiveVersion = versionOverrideResolver.ResolveVersion(
                    pkg.Key,
                    packageId.Id,
                    packageId.Source.Id,
                    pkg.Value);

                logger.LogInformation("Module {ModuleId}@{SourceId} version {Version} is marked for restore", packageId.Id, packageId.Source.Id, effectiveVersion);

                IEnumerable<IModuleRestoreVersionParser> versionParsers = serviceProvider.GetServices<IModuleRestoreVersionParser>();
                foreach (IModuleRestoreVersionParser parser in versionParsers)
                {
                    if (parser.TryParse(effectiveVersion, out version))
                    {
                        break;
                    }
                }

                if (version == null)
                {
                    throw new InvalidOperationException($"Unable to parse version '{effectiveVersion}' for package '{pkg.Key}'.");
                }


                moduleRestoreRequests.Add(DeclaredModuleBuilder.InitNew()
                                                                     .WithPackageId(packageId)
                                                                     .WithVersion(version)
                                                                     .WithExtractPath(Cfg.InstallRoot)
                                                                     .Build());
            }

            return moduleRestoreRequests;
        }

    }
}
