using ContextCompiler.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;
using ContextCompiler.Skills.Abstractions.Configuration;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ContextCompiler.Modules.Loader;

public static class DependencyInjection
{
    private const string ModulesConfigFileName = "ctxc.modules.config.json";
    private const string SkillsConfigFileName = "ctxc.skills.config.json";
    private const string HiddenDirectory = ".ctxc";

    // Section names used inside the config files (schemaVersion 2 layout).
    private const string ModulesSectionName = "modules";
    private const string SkillsSectionName = "skills";

    public static IServiceCollection AddModulesLoaderServices(this IServiceCollection services)
    {
        _ = services.AddOptions();

        _ = services.AddSingleton<IConfigureOptions<ModulesConfig>>(sp =>
            new ConfigureOptions<ModulesConfig>(opts =>
                BindSectionOrRoot(
                    BuildFileConfiguration(sp, ModulesConfigFileName),
                    ModulesSectionName,
                    opts)));

        _ = services.AddSingleton<IConfigureOptions<SkillsConfig>>(sp =>
            new ConfigureOptions<SkillsConfig>(opts =>
            {
                // First apply the skills section from the modules file (if any), then let
                // a dedicated skills file override it.
                BindSectionOrRoot(
                    BuildFileConfiguration(sp, ModulesConfigFileName),
                    SkillsSectionName,
                    opts,
                    bindRootFallback: false);

                BindSectionOrRoot(
                    BuildFileConfiguration(sp, SkillsConfigFileName),
                    SkillsSectionName,
                    opts);
            }));

        return services
            .AddSingleton<IModuleAssemblyLoader, ModuleAssemblyLoader>()
            .AddSingleton<IModulesDiscoverer, ModulesDiscoverer>()
            .AddSingleton<IModulesLoader, ModulesLoader>()
            .AddSingleton<IModuleRegistryBuilder, ModuleRegistryBuilder>()
            .AddSingleton<IDependenciesChecker, DependenciesChecker>()
            .AddTransient<IIntegrityChecker, IntegrityChecker>();
    }

    private static IConfiguration BuildFileConfiguration(IServiceProvider sp, string fileName)
    {
        IWorkingFolder workingFolder = sp.GetRequiredService<IWorkingFolder>();
        string basePath = workingFolder.Path;

        return new ConfigurationBuilder()
            .SetBasePath(basePath)
            // Fallback (lower priority): hidden .ctxc directory
            .AddJsonFile(Path.Combine(HiddenDirectory, fileName), optional: true, reloadOnChange: true)
            // Override (higher priority): file at the workspace root
            .AddJsonFile(fileName, optional: true, reloadOnChange: true)
            .Build();
    }

    private static void BindSectionOrRoot<T>(
        IConfiguration configuration,
        string sectionName,
        T target,
        bool bindRootFallback = true)
        where T : class
    {
        IConfigurationSection section = configuration.GetSection(sectionName);
        if (section.Exists())
        {
            section.Bind(target);
            return;
        }

        if (bindRootFallback)
        {
            configuration.Bind(target);
        }
    }
}
