using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Modules.Handlers;

internal sealed class PurgeHandler(
    IModulesManager moduleManager,
    ILogger<PurgeHandler> logger
) : IPurgeHandler
{
    public Task<int> HandleAsync(string cfgFile, bool keepLocked)
    {
        try
        {
            _ = cfgFile;

            moduleManager.PurgeCache(keepLocked);
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
