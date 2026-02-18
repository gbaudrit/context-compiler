using ContextCompiler.Plugins.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Host.Cli.Handlers;

internal sealed class CtxcPluginsListHandler(IPluginRegistry registry, ILogger<CtxcPluginsListHandler> logger) : ICtxcPluginsListHandler
{
    private readonly System.Text.Json.JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public Task<int> HandleAsync(bool json)
    {
        try
        {
            var items = new[]
            {
                new { Kind = "file-reader", registry.FileReaders.Count },
                new { Kind = "data-reader", registry.DataReaders.Count },
                new { Kind = "engineering", registry.EngineeringModules.Count },
                new { Kind = "transcoder", registry.Transcoders.Count },
                new { Kind = "guard", registry.Guards.Count },
                new { Kind = "view", registry.Views.Count },
                new { Kind = "template", registry.Templates.Count },
                new { Kind = "graph-exporter", registry.GraphExporters.Count }
            };

            if (json)
            {
                Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(items, jsonSerializerOptions));
            }
            else
            {
                foreach (var i in items)
                {
                    Console.WriteLine($"{i.Kind}: {i.Count}");
                }
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

internal sealed class CtxcPluginsAddHandler(ILogger<CtxcPluginsAddHandler> logger) : ICtxcPluginsAddHandler
{
    public Task<int> HandleAsync(string packageId, string? version, string? source)
    {
        logger.LogInformation("Plugins add stub: {PackageId} {Version} {Source}", packageId, version, source);
        return Task.FromResult(0);
    }
}

internal sealed class CtxcPluginsRemoveHandler(ILogger<CtxcPluginsRemoveHandler> logger) : ICtxcPluginsRemoveHandler
{
    public Task<int> HandleAsync(string packageId)
    {
        logger.LogInformation("Plugins remove stub: {PackageId}", packageId);
        return Task.FromResult(0);
    }
}
