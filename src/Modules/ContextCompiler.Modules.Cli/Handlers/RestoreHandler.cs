using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Cli.Handlers;

internal sealed class RestoreHandler(
    IModulesManager modulesManager,
    IModulesLoader modulesLoader,
    IModulesLoadConfigLocator modulesLoadConfigLocator,
    IModulesLoadConfigProvider modulesLoadConfigProvider,
    ILogger<RestoreHandler> logger
) : IRestoreHandler
{
    public async Task<int> HandleAsync(bool debug, string cfgFile)
    {
        try
        {
            if (debug)
            {
                _ = System.Diagnostics.Debugger.Launch();
                System.Diagnostics.Debugger.Break();
            }

            string? configPath = modulesLoadConfigLocator.Locate(cfgFile, "", "");
            _ = modulesLoadConfigProvider.GetConfigOrDefault(configPath);

            ModuleLockFile lf = await modulesManager.RestoreAndLockAsync(CancellationToken.None);
            modulesLoader.SaveLockFile(lf);
            Console.WriteLine($"Lock file written: {Path.GetFullPath(cfgFile)}");
            return 0;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return 1;
        }
    }
}
