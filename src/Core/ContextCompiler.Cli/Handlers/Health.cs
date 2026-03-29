using System.Text.Json;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Handlers;

internal sealed class CtxcHealthHandler(ILogger<CtxcHealthHandler> logger) : ICtxcHealthHandler
{
    private static readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    public async Task<int> HandleAsync(string input, string format, int? failBelow)
    {
        try
        {
            int fragments = 0;
            int findings = 0;
            string idx = Path.Combine(input, "evidence.index.json");
            if (File.Exists(idx))
            {
                try
                {
                    using JsonDocument doc = JsonDocument.Parse(await File.ReadAllTextAsync(idx));
                    fragments = doc.RootElement.ValueKind == JsonValueKind.Array ? doc.RootElement.GetArrayLength() : 0;
                }
                catch { }
            }
            string sec = Path.Combine(input, "security.report.md");
            if (File.Exists(sec))
            {
                findings = (await File.ReadAllLinesAsync(sec)).Count(l => l.StartsWith("- ", StringComparison.Ordinal));
            }
            int score = Math.Max(0, 100 - (findings * 5));

            if (format.Equals("json", StringComparison.OrdinalIgnoreCase))
            {
                var payload = new { fragments, findings, score };
                Console.WriteLine(JsonSerializer.Serialize(payload, jsonSerializerOptions));
            }
            else
            {
                Console.WriteLine($"Fragments={fragments} Findings={findings} Score={score}");
            }

            return failBelow.HasValue && score < failBelow.Value ? 1 : 0;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return 1;
        }
    }
}
