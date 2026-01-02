using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Host.Cli.Handlers;

internal sealed class CtxcHealthHandler : ICtxcHealthHandler
{
    private readonly ILogger<CtxcHealthHandler> _logger;
    private static readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    public CtxcHealthHandler(ILogger<CtxcHealthHandler> logger) => _logger = logger;

    public async Task<int> HandleAsync(string input, string format, int? failBelow)
    {
        try
        {
            int fragments = 0;
            int findings = 0;
            var idx = Path.Combine(input, "evidence.index.json");
            if (File.Exists(idx))
            {
                try
                {
                    using var doc = JsonDocument.Parse(await File.ReadAllTextAsync(idx));
                    fragments = doc.RootElement.ValueKind == JsonValueKind.Array ? doc.RootElement.GetArrayLength() : 0;
                }
                catch { }
            }
            var sec = Path.Combine(input, "security.report.md");
            if (File.Exists(sec))
            {
                findings = (await File.ReadAllLinesAsync(sec)).Count(l => l.StartsWith("- ", StringComparison.Ordinal));
            }
            int score = Math.Max(0, 100 - findings * 5);

            if (format.Equals("json", StringComparison.OrdinalIgnoreCase))
            {
                var payload = new { fragments, findings, score };
                Console.WriteLine(JsonSerializer.Serialize(payload, jsonSerializerOptions));
            }
            else
            {
                Console.WriteLine($"Fragments={fragments} Findings={findings} Score={score}");
            }

            if (failBelow.HasValue && score < failBelow.Value) return 1;
            return 0;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Internal error");
            return 1;
        }
    }
}
