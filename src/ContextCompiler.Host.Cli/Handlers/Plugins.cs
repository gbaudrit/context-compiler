using ContextCompiler.Abstractions.Pipelines;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Host.Cli.Handlers;

internal sealed class CtxcPluginsListHandler : ICtxcPluginsListHandler
{
    private readonly IPluginRegistry _registry;
    private readonly ILogger<CtxcPluginsListHandler> _logger;
    private System.Text.Json.JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };


    public CtxcPluginsListHandler(IPluginRegistry registry, ILogger<CtxcPluginsListHandler> logger)
    {
        _registry = registry;
        _logger = logger;
    }

    public Task<int> HandleAsync(bool json)
    {
        try
        {
            var items = new[]
            {
                new { Kind = "file-reader", Count = _registry.FileReaders.Count },
                new { Kind = "data-reader", Count = _registry.DataReaders.Count },
                new { Kind = "engineering", Count = _registry.EngineeringModules.Count },
                new { Kind = "transcoder", Count = _registry.Transcoders.Count },
                new { Kind = "guard", Count = _registry.Guards.Count },
                new { Kind = "view", Count = _registry.Views.Count },
                new { Kind = "template", Count = _registry.Templates.Count },
                new { Kind = "graph-exporter", Count = _registry.GraphExporters.Count }
            };

            if (json)
            {
                Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(items, jsonSerializerOptions));
            }
            else
            {
                foreach (var i in items) Console.WriteLine($"{i.Kind}: {i.Count}");
            }
            return Task.FromResult(0);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Internal error");
            return Task.FromResult(1);
        }
    }
}

internal sealed class CtxcPluginsAddHandler : ICtxcPluginsAddHandler
{
    private readonly ILogger<CtxcPluginsAddHandler> _logger;
    public CtxcPluginsAddHandler(ILogger<CtxcPluginsAddHandler> logger) => _logger = logger;
    public Task<int> HandleAsync(string packageId, string? version, string? source)
    {
        _logger.LogInformation("Plugins add stub: {PackageId} {Version} {Source}", packageId, version, source);
        return Task.FromResult(0);
    }
}

internal sealed class CtxcPluginsRemoveHandler : ICtxcPluginsRemoveHandler
{
    private readonly ILogger<CtxcPluginsRemoveHandler> _logger;
    public CtxcPluginsRemoveHandler(ILogger<CtxcPluginsRemoveHandler> logger) => _logger = logger;
    public Task<int> HandleAsync(string packageId)
    {
        _logger.LogInformation("Plugins remove stub: {PackageId}", packageId);
        return Task.FromResult(0);
    }
}
