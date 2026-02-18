using ContextCompiler.Plugins.Abstractions.Configuration;
using ContextCompiler.Plugins.Abstractions.Loading;
using ContextCompiler.Plugins.Loader.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Plugins.Loader;

public static class DependencyInjection
{

    public static IServiceCollection AddPluginsLoaderServices(this IServiceCollection services)
    {
        return services.AddSingleton<IPluginsLoadConfigProvider, JsonPluginsLoaderConfigProvider>()
            .AddTransient<IPluginsLoadConfigLocator, DefaultConfigLocator>()
            .AddSingleton<IPluginAssemblyLoader, PluginAssemblyLoader>()
            .AddSingleton<IPluginsDiscoverer, PluginsDiscoverer>()
            .AddSingleton<IPluginsLoader, PluginsLoader>()
            .AddSingleton<IPluginRegistryBuilder, PluginRegistryBuilder>();
    }

}
