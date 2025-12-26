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
                var cfg = JsonSerializer.Deserialize<CtxcConfig>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    AllowTrailingCommas = true
                }) ?? new CtxcConfig();
                if (cfg.Excel?.Files is not null)
                {
                    cfg.Excel.Files = cfg.Excel.Files
                        .OrderBy(f => f.Match, StringComparer.Ordinal)
                        .ToList();
                    foreach (var f in cfg.Excel.Files)
                    {
                        f.Extracts = f.Extracts
                            .OrderBy(e => e.Id, StringComparer.Ordinal)
                            .ToList();
                        foreach (var e in f.Extracts)
                        {
                            if (e.Select is not null)
                                e.Select = e.Select.OrderBy(c => c, StringComparer.Ordinal).ToList();
                            if (e.Exclude is not null)
                                e.Exclude = e.Exclude.OrderBy(c => c, StringComparer.Ordinal).ToList();
                            if (e.Rename is not null)
                                e.Rename = e.Rename.OrderBy(kv => kv.Key, StringComparer.Ordinal).ToDictionary(kv => kv.Key, kv => kv.Value);
                            if (e.Where is not null)
                                e.Where = e.Where.OrderBy(w => w.Column, StringComparer.Ordinal).ToList();
                        }
                    }
                }
                // context: no reordering; keep as provided
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
