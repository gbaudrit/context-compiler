using ContextCompiler.Plugins.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Plugins.NuGet;

public static class DependencyInjection
{

    public static IServiceCollection AddPluginsNuGetRestoreServices(this IServiceCollection services)
    {
        return services.AddSingleton<INuGetPluginStore, NuGetPluginStore>()
                       .AddTransient<ITrustPolicy, TrustPolicy>()
                       .AddSingleton<IPluginManager, PluginManager>();
    }

}
