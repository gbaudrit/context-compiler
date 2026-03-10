using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Loader
{
    public class ModulesLoader(IModulesDiscoverer modulesDiscoverer, IModuleRegistryBuilder moduleRegistryBuilder, ILogger<ModulesLoader> logger) : IModulesLoader
    {

        public async Task<IEnumerable<Type>> LoadFromFolder(string path, IServiceCollection services, CancellationToken cancellationToken)
        {
            logger.LogInformation("Starting module discovery in folder: {Path}", path);

            IEnumerable<Type> moduleTypes = await modulesDiscoverer.Discover(path, cancellationToken);

            logger.LogInformation("Discovered {Count} module(s) in folder: {Path}", moduleTypes.Count(), path);

            moduleRegistryBuilder.RegisterModuleServices(services, moduleTypes);

            return moduleTypes;
        }

        public async Task LoadFromAssemblies(Assembly[] assemblies, IServiceCollection services)
        {
            logger.LogInformation("Starting module discovery in assemblies: {Assemblies}", string.Join(", ", assemblies.Select(a => a.GetName().Name)));

            foreach (Assembly assembly in assemblies)
            {
                moduleRegistryBuilder.RegisterModuleServices(services, assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract));
            }
        }

    }
}
