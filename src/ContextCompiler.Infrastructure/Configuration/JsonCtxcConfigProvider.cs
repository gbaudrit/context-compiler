using System.Text.Json;
using ContextCompiler.Abstractions.Configuration;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Infrastructure.Configuration;

public sealed class JsonCtxcConfigProvider : ICtxcConfigProvider
{
    private readonly ILogger<JsonCtxcConfigProvider> _logger;
    private readonly object _lock = new();
    private CtxcConfig? _cached;
    private string? _cachedPath;
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true
    };

    public JsonCtxcConfigProvider(ILogger<JsonCtxcConfigProvider> logger)
    {
        _logger = logger;
    }

    public CtxcConfig GetConfigOrDefault(string? configPath)
    {
        var cached = _cached;
        if (cached is not null)
            return cached;

        lock (_lock)
        {
            if (_cached is not null)
                return _cached;

            var path = configPath;
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                _logger.LogInformation("No config provided or file missing: using defaults");
                _cached = new CtxcConfig();
                _cachedPath = path;
                return _cached;
            }
            try
            {
                var json = File.ReadAllText(path);
                var cfg = JsonSerializer.Deserialize<CtxcConfig>(json, JsonOptions) ?? new CtxcConfig();

                _cached = cfg;
                _cachedPath = path;
                return _cached;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to read config; using defaults");
                _cached = new CtxcConfig();
                _cachedPath = path;
                return _cached;
            }
        }
    }
}
