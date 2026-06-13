using ContextCompiler.Cli.Skills.Handlers;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContextCompiler.Cli.Modules.Handlers;

internal sealed class RestoreHandler(
    IModulesManager modulesManager,
    IModulesLoader modulesLoader,
    IOptions<ModulesConfig> cfgOptions,
    [FromKeyedServices(StoreKeys.Root)] IStore rootStore,
    ISkillsRestoreHandler skillsRestoreHandler,
    ILogger<RestoreHandler> logger
) : IRestoreHandler
{
    public async Task<int> HandleAsync(string cfgFile, bool force, bool clean, IReadOnlyDictionary<string, string> runModules, CancellationToken cancellationToken, string scope = "all")
    {
        try
        {
            //if (debug)
            //{
            //    _ = System.Diagnostics.Debugger.Launch();
            //    System.Diagnostics.Debugger.Break();
            //}

            ModulesConfig loadConfig = cfgOptions.Value;
            loadConfig.ActiveScope = scope;

            if (clean)
            {
                if (!modulesLoader.Clean())
                {
                    Console.WriteLine($"Failed to clean lock file: {Path.GetFullPath(cfgFile)}");
                    return 1;
                }
                Console.WriteLine($"Lock file cleaned: {Path.GetFullPath(cfgFile)}");
                string installRoot = ResolveRootPath(loadConfig.InstallRoot);
                if (Path.Exists(installRoot))
                {
                    Directory.Delete(installRoot, true);
                }
                Console.WriteLine($"Modules directory deleted: {installRoot}");
            }

            foreach (KeyValuePair<string, string> runModule in runModules)
            {
                loadConfig.Packages[runModule.Key] = runModule.Value;
            }

            ModuleLockFile lf = await modulesManager.RestoreAndLockAsync(force, cancellationToken);
            modulesLoader.SaveLockFile(lf);
            modulesLoader.SaveRunModules(runModules);
            Console.WriteLine($"Lock file written: {Path.GetFullPath(cfgFile)}");

            int skillsRestoreExitCode = await skillsRestoreHandler.HandleAsync(cancellationToken);
            return skillsRestoreExitCode == 0 ? 0 : skillsRestoreExitCode;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return 1;
        }
    }

    private string ResolveRootPath(string path)
    {
        return Path.IsPathRooted(path)
            ? path
            : rootStore.Container.GetResource(path).Uri.AbsolutePath;
    }
}
