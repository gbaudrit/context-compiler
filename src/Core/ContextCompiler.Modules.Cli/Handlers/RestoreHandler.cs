using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using NuGet.Packaging;

namespace ContextCompiler.Modules.Cli.Handlers;

internal sealed class RestoreHandler(
    IModulesManager modulesManager,
    IModulesLoader modulesLoader,
    IOptions<ModulesConfig> cfgOptions,
    ISkillsRestoreHandler skillsRestoreHandler,
    ILogger<RestoreHandler> logger
) : IRestoreHandler
{
    public async Task<int> HandleAsync(bool debug, string cfgFile, bool force, bool clean, IReadOnlyDictionary<string, string> runModules)
    {
        try
        {
            //if (debug)
            //{
            //    _ = System.Diagnostics.Debugger.Launch();
            //    System.Diagnostics.Debugger.Break();
            //}

            ModulesConfig loadConfig = cfgOptions.Value;

            if (clean)
            {
                if (!modulesLoader.Clean())
                {
                    Console.WriteLine($"Failed to clean lock file: {Path.GetFullPath(cfgFile)}");
                    return 1;
                }
                Console.WriteLine($"Lock file cleaned: {Path.GetFullPath(cfgFile)}");
                if (Path.Exists(loadConfig.InstallRoot))
                {
                    Directory.Delete(loadConfig.InstallRoot, true);
                }
                Console.WriteLine($"Modules directory deleted: {Path.GetFullPath(loadConfig.InstallRoot)}");
            }

            loadConfig.Packages.AddRange(runModules);

            ModuleLockFile lf = await modulesManager.RestoreAndLockAsync(force, CancellationToken.None);
            modulesLoader.SaveLockFile(lf);
            modulesLoader.SaveRunModules(runModules);
            Console.WriteLine($"Lock file written: {Path.GetFullPath(cfgFile)}");

            int skillsRestoreExitCode = await skillsRestoreHandler.HandleAsync(cfgFile);
            return skillsRestoreExitCode == 0 ? 0 : skillsRestoreExitCode;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return 1;
        }
    }
}
