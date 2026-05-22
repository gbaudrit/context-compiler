using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Loader;
using ContextCompiler.Modules.Abstractions.Skills;
using ContextCompiler.Modules.Skills;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules;

public static class DependencyInjection
{

    public static IServiceCollection AddModules(this IServiceCollection services)
    {
        return services.AddTransient<IModuleMetadatasBuilder, ModuleMetadatasBuilder>()
            .AddTransient<IModuleRestoreRequestBuilder, ModuleRestoreRequestBuilder>()
            .AddTransient<IModuleRestoreRequestResultBuilder, ModuleRestoreRequestResultBuilder>()
            .AddTransient<IModuleRestoreVersionBuilder, ModuleRestoreVersionBuilder>()
            .AddTransient<IModuleDependencyBuilder, ModuleDependencyBuilder>()
            .AddTransient<IModuleRestoreIdBuilder, ModuleRestoreIdBuilder>()
            .AddTransient<IModuleRestoreSourceBuilder, ModuleRestoreSourceBuilder>()
            .AddTransient<ITrustPolicy, TrustPolicy>()
            .AddTransient<IModuleRestorePackageIdParser, ModuleRestorePackageIdDefaultParser>()
            .AddTransient<IModuleRestoreVersionParser, ModuleRestoreVersionNpmLikeParser>()
            .AddTransient<ISourceBuilder, SourceBuilder>()
            .AddSingleton<ISkillInstallPlanner, SkillInstallPlanner>()
            .AddSingleton<ISkillsCompiler, SkillsCompiler>()
            .AddSingleton<IModulesManager, ModulesManager>()
            .AddSingleton<IModulesToRestoreProvider, ModulesToRestoreProvider>()
            .AddSingleton<IModulesSourcesProvider, FromConfigurationSourcesProvider>();
    }

}
