using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules
{
    internal sealed class ModulesToRestoreProvider(IModulesLoadConfigProvider cfg,
                                            IModuleRestoreRequestBuilder moduleRestoreRequestBuilder,
                                            IServiceProvider serviceProvider,
                                            ILogger<ModulesToRestoreProvider> logger) : IModulesToRestoreProvider
    {

        public IEnumerable<IModuleRestoreRequest> ModulesToRestore()
        {
            IList<IModuleRestoreRequest> moduleRestoreRequests = [];

            foreach (KeyValuePair<string, string> pkg in cfg.Current.Packages)
            {
                if (string.IsNullOrWhiteSpace(pkg.Key))
                {
                    throw new InvalidOperationException("Package ID cannot be null or whitespace.");
                }
                if (string.IsNullOrWhiteSpace(pkg.Value))
                {
                    throw new InvalidOperationException($"Version for package {pkg.Key} cannot be null or whitespace.");
                }

                logger.LogInformation("Module {ModuleId} version {Version} is marked for restore", pkg.Key, pkg.Value);

                IModuleRestoreVersion? version = null;
                IModuleRestoreId? packageId = null;
                IEnumerable<IModuleRestoreVersionParser> versionParsers = serviceProvider.GetServices<IModuleRestoreVersionParser>();
                IEnumerable<IModuleRestorePackageIdParser> packageIdParsers = serviceProvider.GetServices<IModuleRestorePackageIdParser>();
                foreach (IModuleRestoreVersionParser parser in versionParsers)
                {
                    if (parser.TryParse(pkg.Value, out version))
                    {
                        break;
                    }
                }

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

                if (version == null)
                {
                    throw new InvalidOperationException($"Unable to parse version '{pkg.Value}' for package '{pkg.Key}'.");
                }


                moduleRestoreRequests.Add(moduleRestoreRequestBuilder.InitNew()
                                                                     .WithPackageId(packageId)
                                                                     .WithVersion(version)
                                                                     .WithExtractPath(cfg.Current.InstallRoot)
                                                                     .Build());
            }

            return moduleRestoreRequests;
        }

    }
}
