using System.Text.Json;

using ContextCompiler.Abstractions.Configuration;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Configuration.Json;

public sealed class JsonCtxcConfigProvider(ILogger<JsonCtxcConfigProvider> logger) : ICtxcConfigProvider
{
    private readonly ILogger<JsonCtxcConfigProvider> _logger = logger;
    private readonly Lock _lock = new();
    private CtxcConfig? _cached;
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true
    };

    public ICtxcConfig Current => _cached ?? throw new InvalidOperationException("Config not loaded");

    public ICtxcConfig GetConfigOrDefault(string? configPath)
    {
        CtxcConfig? cached = _cached;
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
                _cached = new CtxcConfig();
                return _cached;
            }
            try
            {
                string json = File.ReadAllText(path);
                CtxcConfig cfg = JsonSerializer.Deserialize<CtxcConfig>(json, JsonOptions) ?? new CtxcConfig();

                _cached = cfg;
                return _cached;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to read config; using defaults");
                _cached = new CtxcConfig();
                return _cached;
            }
        }
    }
}
