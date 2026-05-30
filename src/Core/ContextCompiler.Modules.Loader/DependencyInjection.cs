using ContextCompiler.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;
using ContextCompiler.Modules.Loader.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Loader;

public static class DependencyInjection
{

    public static IServiceCollection AddModulesLoaderServices(this IServiceCollection services)
    {

        return services.AddSingleton<JsonModulesLoaderConfigProvider>()
            .AddSingleton<IModulesLoadConfigProvider>(sp =>
            {
                IWorkingFolder workingFolder = sp.GetRequiredService<IWorkingFolder>();
                JsonModulesLoaderConfigProvider jsonModulesLoaderConfigProvider = sp.GetRequiredService<JsonModulesLoaderConfigProvider>();
                IModulesLoadConfigLocator modulesLoadConfigLocator = sp.GetRequiredService<IModulesLoadConfigLocator>();
                _ = jsonModulesLoaderConfigProvider.GetConfigOrDefault(modulesLoadConfigLocator.Locate(workingFolder.Path, "", ""));

                return jsonModulesLoaderConfigProvider;
            })
            .AddSingleton<JsonSkillsLoaderConfigProvider>()
            .AddSingleton<ISkillsLoadConfigProvider>(sp =>
            {
                IWorkingFolder workingFolder = sp.GetRequiredService<IWorkingFolder>();
                JsonSkillsLoaderConfigProvider jsonSkillsLoaderConfigProvider = sp.GetRequiredService<JsonSkillsLoaderConfigProvider>();
                ISkillsLoadConfigLocator skillsLoadConfigLocator = sp.GetRequiredService<ISkillsLoadConfigLocator>();
                _ = jsonSkillsLoaderConfigProvider.GetConfigOrDefault(skillsLoadConfigLocator.Locate(workingFolder.Path, "", ""));

                return jsonSkillsLoaderConfigProvider;
            })
            .AddTransient<IModulesLoadConfigLocator, ModulesConfigLocator>()
            .AddTransient<ISkillsLoadConfigLocator, SkillsConfigLocator>()
            .AddSingleton<IModuleAssemblyLoader, ModuleAssemblyLoader>()
            .AddSingleton<IModulesDiscoverer, ModulesDiscoverer>()
            .AddSingleton<IModulesLoader, ModulesLoader>()
            .AddSingleton<IModuleRegistryBuilder, ModuleRegistryBuilder>()
            .AddSingleton<IDependenciesChecker, DependenciesChecker>()
            .AddTransient<IIntegrityChecker, IntegrityChecker>();
    }

}
