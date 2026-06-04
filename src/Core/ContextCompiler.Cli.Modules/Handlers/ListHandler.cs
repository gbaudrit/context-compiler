using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Modules.Handlers;

internal sealed class ListHandler(
    IModulesManager modulesManager,
    ILogger<ListHandler> logger
) : IListHandler
{
    public Task<int> HandleAsync(string cfgFile)
    {
        try
        {
            _ = cfgFile;

            foreach ((string? id, string? ver, string? sha) in modulesManager.ListInstalled())
            {
                Console.WriteLine($"{id} {ver} {sha}");
            }

            return Task.FromResult(0);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return Task.FromResult(1);
        }
    }
}
