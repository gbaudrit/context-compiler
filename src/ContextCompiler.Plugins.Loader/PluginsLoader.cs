using ContextCompiler.Plugins.Abstractions.Loading;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.Loader
{
    public class PluginsLoader(IPluginsDiscoverer pluginsDiscoverer, IPluginRegistryBuilder pluginRegistryBuilder, ILogger<PluginsLoader> logger) : IPluginsLoader
    {

        public async Task LoadFromFolder(string path, IServiceCollection services, CancellationToken cancellationToken)
        {
            logger.LogInformation("Starting plugin discovery in folder: {Path}", path);

            IEnumerable<Type> pluginTypes = await pluginsDiscoverer.Discover(path, cancellationToken);

            logger.LogInformation("Discovered {Count} plugin(s) in folder: {Path}", pluginTypes.Count(), path);

            pluginRegistryBuilder.RegisterPluginServices(services, pluginTypes);
        }

    }
}
