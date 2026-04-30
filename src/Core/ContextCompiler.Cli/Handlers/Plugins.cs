using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Handlers;

internal sealed class CtxcModulesListHandler(IModulesRegistry registry, ILogger<CtxcModulesListHandler> logger) : ICtxcModulesListHandler
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

internal sealed class CtxcModulesAddHandler(ILogger<CtxcModulesAddHandler> logger) : ICtxcModulesAddHandler
{
    public Task<int> HandleAsync(string packageId, string? version, string? source)
    {
        logger.LogInformation("Modules add stub: {PackageId} {Version} {Source}", packageId, version, source);
        return Task.FromResult(0);
    }
}

internal sealed class CtxcModulesRemoveHandler(ILogger<CtxcModulesRemoveHandler> logger) : ICtxcModulesRemoveHandler
{
    public Task<int> HandleAsync(string packageId)
    {
        logger.LogInformation("Modules remove stub: {PackageId}", packageId);
        return Task.FromResult(0);
    }
}
