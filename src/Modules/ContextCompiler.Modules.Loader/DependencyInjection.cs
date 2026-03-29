using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;
using ContextCompiler.Modules.Loader.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Loader;

public static class DependencyInjection
{

    public static IServiceCollection AddModulesLoaderServices(this IServiceCollection services)
    {
        return services.AddSingleton<IModulesLoadConfigProvider, JsonModulesLoaderConfigProvider>()
            .AddTransient<IModulesLoadConfigLocator, DefaultConfigLocator>()
            .AddSingleton<IModuleAssemblyLoader, ModuleAssemblyLoader>()
            .AddSingleton<IModulesDiscoverer, ModulesDiscoverer>()
            .AddSingleton<IModulesLoader, ModulesLoader>()
            .AddSingleton<IModuleRegistryBuilder, ModuleRegistryBuilder>()
            .AddSingleton<IDependenciesChecker, DependenciesChecker>();
    }

}
