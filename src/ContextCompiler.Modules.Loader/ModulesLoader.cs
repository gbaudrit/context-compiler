using ContextCompiler.Modules.Abstractions.Loading;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Loader
{
    public class ModulesLoader(IModulesDiscoverer modulesDiscoverer, IModuleRegistryBuilder moduleRegistryBuilder, ILogger<ModulesLoader> logger) : IModulesLoader
    {

        public async Task LoadFromFolder(string path, IServiceCollection services, CancellationToken cancellationToken)
        {
            logger.LogInformation("Starting module discovery in folder: {Path}", path);

            IEnumerable<Type> moduleTypes = await modulesDiscoverer.Discover(path, cancellationToken);

            logger.LogInformation("Discovered {Count} module(s) in folder: {Path}", moduleTypes.Count(), path);

            moduleRegistryBuilder.RegisterModuleServices(services, moduleTypes);
        }

    }
}
