using System.Text.Json;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Configuration.Json.Sections;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Configuration.Json;

public sealed class JsonCtxcConfigProvider(ILogger<JsonCtxcConfigProvider> logger) : IConfigProvider
{
    private readonly ILogger<JsonCtxcConfigProvider> _logger = logger;
    private readonly Lock _lock = new();
    private RootConfigSection? _cached;
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true
    };

    public IRootConfigSection Current => _cached ?? throw new InvalidOperationException("Config not loaded");

    public IRootConfigSection GetConfigOrDefault(string? configPath)
    {
        RootConfigSection? cached = _cached;
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
                _cached = new RootConfigSection();
                return _cached;
            }
            try
            {
                string json = File.ReadAllText(path);
                RootConfigSection cfg = JsonSerializer.Deserialize<RootConfigSection>(json, JsonOptions) ?? new RootConfigSection();

                _cached = cfg;
                return _cached;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to read config; using defaults");
                _cached = new RootConfigSection();
                return _cached;
            }
        }
    }
}
