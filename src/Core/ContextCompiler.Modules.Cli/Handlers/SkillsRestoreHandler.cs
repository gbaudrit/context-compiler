using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.DependencyInjection;
using ContextCompiler.Configuration.Json;
using ContextCompiler.Core;
using ContextCompiler.Core.DependencyInjectionBuilders;
using ContextCompiler.Infrastructure;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;
using ContextCompiler.Modules.Abstractions.Skills;
using ContextCompiler.Modules.Loader;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Cli.Handlers;

internal sealed class SkillsRestoreHandler(
    IWorkingFolder workingFolder,
    ILogger<SkillsRestoreHandler> logger) : ISkillsRestoreHandler
{
    public async Task<int> HandleAsync(string cfgFile)
    {
        try
        {
            SkillsRestoreResult result = await RestoreSkillsAsync(cfgFile, CancellationToken.None);
            Console.WriteLine($"Skills lock file written with {result.LockFile.Skills.Count} skill(s).");
            return 0;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return 1;
        }
    }

    public async Task<SkillsRestoreResult> RestoreSkillsAsync(string cfgFile, CancellationToken cancellationToken)
    {
        ServiceCollection services = new();
        IContextCompilerBuilder contextCompilerBuilder = services.AddDependencyInjectionBuilders();

        _ = services.AddLogging(x => x.AddSimpleConsole(o => o.SingleLine = true))
            .AddSingleton(workingFolder)
            .AddCoreServices()
            .AddJsonConfiguration()
            .AddModules()
            .AddModulesLoaderServices()
            .AddDefaultInfrastructure();



        using ServiceProvider bootstrapProvider = services.BuildServiceProvider();
        IModulesLoadConfigLocator locator = bootstrapProvider.GetRequiredService<IModulesLoadConfigLocator>();
        IModulesLoadConfigProvider modulesConfigProvider = bootstrapProvider.GetRequiredService<IModulesLoadConfigProvider>();
        ISkillsLoadConfigProvider skillsConfigProvider = bootstrapProvider.GetRequiredService<ISkillsLoadConfigProvider>();

        string? configPath = locator.Locate(cfgFile, "", "");
        IModulesLoadConfig modulesConfig = modulesConfigProvider.GetConfigOrDefault(configPath);
        _ = skillsConfigProvider.GetConfigOrDefault(configPath);

        IModulesLoader modulesLoader = bootstrapProvider.GetRequiredService<IModulesLoader>();
        string installRoot = Path.IsPathRooted(modulesConfig.InstallRoot)
            ? modulesConfig.InstallRoot
            : Path.Combine(workingFolder.Path, modulesConfig.InstallRoot.Replace('/', Path.DirectorySeparatorChar));

        _ = await modulesLoader.LoadFromFolder(contextCompilerBuilder, installRoot, cancellationToken);

        using ServiceProvider restoreProvider = services.BuildServiceProvider();
        _ = restoreProvider.GetRequiredService<IModulesLoadConfigProvider>().GetConfigOrDefault(configPath);
        _ = restoreProvider.GetRequiredService<ISkillsLoadConfigProvider>().GetConfigOrDefault(configPath);

        ISkillsRestorer restorer = restoreProvider.GetRequiredService<ISkillsRestorer>();
        return await restorer.RestoreAsync(cancellationToken);
    }
}
