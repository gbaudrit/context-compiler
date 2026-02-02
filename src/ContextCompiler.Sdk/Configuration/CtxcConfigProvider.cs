using System.Text.Json;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Sdk.Configuration;

public interface ICtxcConfigProvider
{
    CtxcConfig GetConfigOrDefault(string? configPath);
}

public sealed class JsonCtxcConfigProvider(ILogger<JsonCtxcConfigProvider> logger) : ICtxcConfigProvider
{
    private static readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true,
    };

    public CtxcConfig GetConfigOrDefault(string? configPath)
    {
        if (string.IsNullOrWhiteSpace(configPath) || !File.Exists(configPath))
        {
            logger.LogInformation("No config provided or file missing: using defaults");
            return new CtxcConfig();
        }
        try
        {
            string json = File.ReadAllText(configPath);
            CtxcConfig cfg = JsonSerializer.Deserialize<CtxcConfig>(json, jsonSerializerOptions) ?? new CtxcConfig();
            // Determinism: sort arrays
            if (cfg.Excel?.Files is not null)
            {
                cfg.Excel.Files = [.. cfg.Excel.Files.OrderBy(f => f.Path, StringComparer.Ordinal)];
                foreach (ExcelFileConfig f in cfg.Excel.Files)
                {
                    f.Extracts = [.. f.Extracts.OrderBy(e => e.Id, StringComparer.Ordinal)];
                    foreach (ExcelExtractConfig e in f.Extracts)
                    {
                        if (e.Columns is not null)
                        {
                            e.Columns = [.. e.Columns.OrderBy(c => c, StringComparer.Ordinal)];
                        }

                        if (e.Where is not null)
                        {
                            e.Where = [.. e.Where.OrderBy(w => w.Column, StringComparer.Ordinal)];
                        }

                        if (e.Rename is not null)
                        {
                            e.Rename = e.Rename.OrderBy(kv => kv.Key, StringComparer.Ordinal).ToDictionary(kv => kv.Key, kv => kv.Value);
                        }
                    }
                }
            }
            return cfg;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to read config; using defaults");
            return new CtxcConfig();
        }
    }
}
