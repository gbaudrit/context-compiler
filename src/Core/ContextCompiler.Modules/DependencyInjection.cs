using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Loader;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules;

public static class DependencyInjection
{

    public static IServiceCollection AddModules(this IServiceCollection services)
    {
        return services.AddTransient<IModuleMetadatasBuilder, ModuleMetadatasBuilder>()
            .AddTransient<IDeclaredModuleBuilder, DeclaredModuleBuilder>()
            .AddTransient<IModuleRestoreRequestResultBuilder, ModuleRestoreRequestResultBuilder>()
            .AddTransient<IModuleRestoreVersionBuilder, ModuleRestoreVersionBuilder>()
            .AddTransient<IModuleDependencyBuilder, ModuleDependencyBuilder>()
            .AddTransient<IModuleRestoreIdBuilder, ModuleRestoreIdBuilder>()
            .AddTransient<IModuleRestoreSourceBuilder, ModuleRestoreSourceBuilder>()
            .AddTransient<ITrustPolicy, TrustPolicy>()
            .AddTransient<IModuleRestorePackageIdParser, ModuleRestorePackageIdDefaultParser>()
            .AddTransient<IModuleRestoreVersionParser, ModuleRestoreVersionNpmLikeParser>()
            .AddTransient<ISourceBuilder, SourceBuilder>()
            .AddSingleton<IModulesManager, ModulesManager>()
            .AddSingleton<IModuleInstallPlanner, ModuleInstallPlanner>()
            .AddSingleton<IDeclaredModulesProvider, DeclaredModulesProvider>()
            .AddSingleton<IModulesSourcesProvider, FromConfigurationSourcesProvider>();
    }

}
