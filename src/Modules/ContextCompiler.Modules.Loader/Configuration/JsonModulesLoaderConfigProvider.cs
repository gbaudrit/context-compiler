using System.Text.Json;

using ContextCompiler.Modules.Abstractions.Configuration;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Loader.Configuration;

public sealed class JsonModulesLoaderConfigProvider(ILogger<JsonModulesLoaderConfigProvider> logger) : IModulesLoadConfigProvider
{
    private readonly ILogger<JsonModulesLoaderConfigProvider> _logger = logger;
    private readonly Lock _lock = new();
    private ModulesConfig? _cached;
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true
    };

    public IModulesLoadConfig Current => _cached ?? throw new InvalidOperationException("Config not loaded");

    public IModulesLoadConfig GetConfigOrDefault(string? configPath)
    {
        ModulesConfig? cached = _cached;
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
                _cached = new ModulesConfig();
                return _cached;
            }
            try
            {
                string json = File.ReadAllText(path);
                ModulesConfig cfg = JsonSerializer.Deserialize<ModulesConfig>(json, JsonOptions) ?? new ModulesConfig();

                _cached = cfg;
                return _cached;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to read config; using defaults");
                _cached = new ModulesConfig();
                return _cached;
            }
        }
    }
}
