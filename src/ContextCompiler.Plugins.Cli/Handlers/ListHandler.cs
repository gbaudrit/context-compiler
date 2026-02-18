using ContextCompiler.Plugins.Abstractions;
using ContextCompiler.Plugins.Abstractions.Configuration;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.Cli.Handlers;

internal sealed class ListHandler(
    IPluginManager pluginManager,
    IPluginsLoadConfigLocator pluginsLoadConfigLocator,
    IPluginsLoadConfigProvider pluginsLoadConfigProvider,
    ILogger<ListHandler> logger
) : IListHandler
{
    public Task<int> HandleAsync(string cfgFile)
    {
        try
        {
            string? configPath = pluginsLoadConfigLocator.Locate(cfgFile, "", "");
            _ = pluginsLoadConfigProvider.GetConfigOrDefault(configPath);

            foreach ((string? id, string? ver, string? sha) in pluginManager.ListInstalled())
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
