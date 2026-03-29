using System.Globalization;
using System.Text;
using System.Text.Json;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Handlers;

internal sealed class CtxcExplainHandler(ILogger<CtxcExplainHandler> logger) : ICtxcExplainHandler
{
    private readonly ILogger<CtxcExplainHandler> _logger = logger;
    private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public async Task<int> HandleAsync(string input, string? outFile, string format)
    {
        try
        {
            string[] artifacts = ["prompt.context.md", "evidence.index.json", "reasoning.graph.json", "security.report.md", "context.health.json"];
            string[] existing = [.. artifacts.Where(a => File.Exists(Path.Combine(input, a)))];

            int fragmentCount = 0;
            int viewCount = Directory.EnumerateFiles(input, "view.*.md", SearchOption.TopDirectoryOnly).Count();

            string idx = Path.Combine(input, "evidence.index.json");
            if (File.Exists(idx))
            {
                try
                {
                    using JsonDocument doc = JsonDocument.Parse(await File.ReadAllTextAsync(idx));
                    fragmentCount = doc.RootElement.ValueKind == JsonValueKind.Array ? doc.RootElement.GetArrayLength() : 0;
                }
                catch { }
            }

            string securitySummary = string.Empty;
            string sec = Path.Combine(input, "security.report.md");
            if (File.Exists(sec))
            {
                string[] lines = await File.ReadAllLinesAsync(sec);
                securitySummary = lines.Length > 0 ? string.Join(" ", lines.Take(5)) + "..." : "";
            }

            if (format.Equals("json", StringComparison.OrdinalIgnoreCase))
            {
                var payload = new { fragments = fragmentCount, views = viewCount, artifacts = existing, securitySummary };
                string text = JsonSerializer.Serialize(payload, jsonSerializerOptions);
                if (outFile is not null)
                {
                    await File.WriteAllTextAsync(outFile, text);
                }
                else
                {
                    Console.WriteLine(text);
                }
            }
            else
            {
                StringBuilder sb = new();
                _ = sb.AppendLine("# Context Explain");
                _ = sb.AppendLine(CultureInfo.InvariantCulture, $"Fragments: {fragmentCount}");
                _ = sb.AppendLine(CultureInfo.InvariantCulture, $"Views: {viewCount}");
                _ = sb.AppendLine("Artifacts:");
                foreach (string? a in existing.OrderBy(s => s, StringComparer.Ordinal))
                {
                    _ = sb.AppendLine("- " + a);
                }

                if (!string.IsNullOrEmpty(securitySummary))
                {
                    _ = sb.AppendLine("Security report summary:");
                    _ = sb.AppendLine(securitySummary);
                }
                string text = sb.ToString();
                if (outFile is not null)
                {
                    await File.WriteAllTextAsync(outFile, text);
                }
                else
                {
                    Console.WriteLine(text);
                }
            }
            return 0;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Internal error");
            return 1;
        }
    }
}
