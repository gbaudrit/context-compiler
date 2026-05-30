using System.Text.Json;

using ContextCompiler.Modules.Abstractions.Configuration;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Loader.Configuration;

public sealed class JsonModulesLoaderConfigProvider(ILogger<JsonModulesLoaderConfigProvider> logger) : IModulesLoadConfigProvider
{
    private readonly ILogger<JsonModulesLoaderConfigProvider> _logger = logger;
    private readonly Lock _lock = new();
    private ModulesLoadDocument? _cached;
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true
    };

    public IModulesLoadConfig Current => _cached?.Modules ?? throw new InvalidOperationException("Config not loaded");

    public IModulesLoadConfig GetConfigOrDefault(string? configPath)
    {
        return GetDocumentOrDefault(configPath).Modules;
    }

    private ModulesLoadDocument GetDocumentOrDefault(string? configPath)
    {
        ModulesLoadDocument? cached = _cached;
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
                _cached = new ModulesLoadDocument();
                return _cached;
            }
            try
            {
                string json = File.ReadAllText(path);
                ModulesLoadDocument cfg = JsonSerializer.Deserialize<ModulesLoadDocument>(json, JsonOptions) ?? new ModulesLoadDocument();

                if (cfg.SchemaVersion != 2)
                {
                    throw new InvalidOperationException($"Unsupported ctxc modules config schemaVersion {cfg.SchemaVersion}. Expected 2.");
                }

                _cached = cfg;
                return _cached;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to read modules config");
                throw;
            }
        }
    }
}
