using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Configuration.Json.Sections;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Configuration.Json;

public sealed class JsonCtxcConfigProvider(IConfiguration configuration, ILogger<JsonCtxcConfigProvider> logger) : IConfigProvider
{
    private readonly ILogger<JsonCtxcConfigProvider> _logger = logger;
    private readonly Lock _lock = new();
    private RootConfigSection? _cached;
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

            try
            {
                _ = configPath;
                RootConfigSection cfg = configuration.Get<RootConfigSection>() ?? new RootConfigSection();

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
