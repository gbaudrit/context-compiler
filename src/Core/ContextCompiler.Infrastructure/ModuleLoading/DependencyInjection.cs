using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Infrastructure.ModuleLoading;

public static class DependencyInjection
{

    public static IServiceCollection AddModuleLoadingServices(this IServiceCollection services)
    {
        // Register core services here
        //services.AddTransient(typeof(IPlugins<>), typeof(GlobalPipelinePlugins<>));
        return services;
    }

}
