using System.Text.Json;

using ContextCompiler.Plugins.Abstractions.Configuration;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.Loader.Configuration;

public sealed class JsonPluginsLoaderConfigProvider(ILogger<JsonPluginsLoaderConfigProvider> logger) : IPluginsLoadConfigProvider
{
    private readonly ILogger<JsonPluginsLoaderConfigProvider> _logger = logger;
    private readonly Lock _lock = new();
    private PluginsConfig? _cached;
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true
    };

    public IPluginsLoadConfig Current => _cached ?? throw new InvalidOperationException("Config not loaded");

    public IPluginsLoadConfig GetConfigOrDefault(string? configPath)
    {
        PluginsConfig? cached = _cached;
        if (cached is not null)
        {
            return cached;
        }

        lock (_lock)
        {
            if (_cached is not null)
            {
                return _cached;
            }

            string? path = configPath;
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                _logger.LogInformation("No config provided or file missing: using defaults");
                _cached = new PluginsConfig();
                return _cached;
            }
            try
            {
                string json = File.ReadAllText(path);
                PluginsConfig cfg = JsonSerializer.Deserialize<PluginsConfig>(json, JsonOptions) ?? new PluginsConfig();

                _cached = cfg;
                return _cached;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to read config; using defaults");
                _cached = new PluginsConfig();
                return _cached;
            }
        }
    }
}
