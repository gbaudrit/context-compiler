using ContextCompiler.Abstractions.Plugins;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Infrastructure.PluginLoading;

public static class DependencyInjection
{

    public static IServiceCollection AddPluginLoadingServices(this IServiceCollection services)
    {
        // Register core services here
        //services.AddTransient(typeof(IPlugins<>), typeof(GlobalPipelinePlugins<>));
        return services;
    }

}
