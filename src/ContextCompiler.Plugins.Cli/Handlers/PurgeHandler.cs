using ContextCompiler.Plugins.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.Cli.Handlers;

internal sealed class PurgeHandler(
    IPluginManager pluginManager,
    ILogger<PurgeHandler> logger
) : IPurgeHandler
{
    public Task<int> HandleAsync(string cfgFile, bool keepLocked)
    {
        try
        {
            _ = cfgFile;

            pluginManager.PurgeCache(keepLocked);
            Console.WriteLine("Cache purged.");
            return Task.FromResult(0);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return Task.FromResult(1);
        }
    }
}
