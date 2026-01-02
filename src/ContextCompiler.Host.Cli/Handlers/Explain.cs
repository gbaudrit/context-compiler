using System.Globalization;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Host.Cli.Handlers;

internal sealed class CtxcExplainHandler : ICtxcExplainHandler
{
    private readonly ILogger<CtxcExplainHandler> _logger;
    JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public CtxcExplainHandler(ILogger<CtxcExplainHandler> logger) => _logger = logger;

    public async Task<int> HandleAsync(string input, string? outFile, string format)
    {
        try
        {
            var artifacts = new[] { "prompt.context.md", "evidence.index.json", "reasoning.graph.json", "security.report.md", "context.health.json" };
            var existing = artifacts.Where(a => File.Exists(Path.Combine(input, a))).ToArray();

            int fragmentCount = 0;
            int viewCount = Directory.EnumerateFiles(input, "view.*.md", SearchOption.TopDirectoryOnly).Count();

            var idx = Path.Combine(input, "evidence.index.json");
            if (File.Exists(idx))
            {
                try
                {
                    using var doc = JsonDocument.Parse(await File.ReadAllTextAsync(idx));
                    fragmentCount = doc.RootElement.ValueKind == JsonValueKind.Array ? doc.RootElement.GetArrayLength() : 0;
                }
                catch { }
            }

            var securitySummary = string.Empty;
            var sec = Path.Combine(input, "security.report.md");
            if (File.Exists(sec))
            {
                var lines = await File.ReadAllLinesAsync(sec);
                securitySummary = lines.Length > 0 ? string.Join(" ", lines.Take(5)) + "..." : "";
            }

            if (format.Equals("json", StringComparison.OrdinalIgnoreCase))
            {
                var payload = new { fragments = fragmentCount, views = viewCount, artifacts = existing, securitySummary };
                var text = JsonSerializer.Serialize(payload, jsonSerializerOptions);
                if (outFile is not null) await File.WriteAllTextAsync(outFile, text);
                else Console.WriteLine(text);
            }
            else
            {
                var sb = new StringBuilder();
                sb.AppendLine("# Context Explain");
                sb.AppendLine(CultureInfo.InvariantCulture, $"Fragments: {fragmentCount}");
                sb.AppendLine(CultureInfo.InvariantCulture, $"Views: {viewCount}");
                sb.AppendLine("Artifacts:");
                foreach (var a in existing.OrderBy(s => s, StringComparer.Ordinal)) sb.AppendLine("- " + a);
                if (!string.IsNullOrEmpty(securitySummary))
                {
                    sb.AppendLine("Security report summary:");
                    sb.AppendLine(securitySummary);
                }
                var text = sb.ToString();
                if (outFile is not null) await File.WriteAllTextAsync(outFile, text);
                else Console.WriteLine(text);
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
