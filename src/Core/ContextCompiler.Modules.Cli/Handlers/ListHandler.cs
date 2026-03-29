using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Cli.Handlers;

internal sealed class ListHandler(
    IModulesManager modulesManager,
    IModulesLoadConfigLocator modulesLoadConfigLocator,
    IModulesLoadConfigProvider modulesLoadConfigProvider,
    ILogger<ListHandler> logger
) : IListHandler
{
    public Task<int> HandleAsync(string cfgFile)
    {
        try
        {
            string? configPath = modulesLoadConfigLocator.Locate(cfgFile, "", "");
            _ = modulesLoadConfigProvider.GetConfigOrDefault(configPath);

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
