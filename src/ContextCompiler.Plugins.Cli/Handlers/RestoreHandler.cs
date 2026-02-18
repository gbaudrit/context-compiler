using ContextCompiler.Plugins.Abstractions;
using ContextCompiler.Plugins.Abstractions.Configuration;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.Cli.Handlers;

internal sealed class RestoreHandler(
    IPluginManager pluginManager,
    IPluginsLoadConfigLocator pluginsLoadConfigLocator,
    IPluginsLoadConfigProvider pluginsLoadConfigProvider,
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

            string? configPath = pluginsLoadConfigLocator.Locate(cfgFile, "", "");
            _ = pluginsLoadConfigProvider.GetConfigOrDefault(configPath);

            PluginLockFile lf = await pluginManager.RestoreAndLockAsync(CancellationToken.None);
            pluginManager.SaveLockFile(lf);
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
