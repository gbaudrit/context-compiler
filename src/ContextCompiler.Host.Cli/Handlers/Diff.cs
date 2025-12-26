using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Host.Cli.Handlers;

internal sealed class CtxcDiffHandler : ICtxcDiffHandler
{
    private readonly ILogger<CtxcDiffHandler> _logger;
    public CtxcDiffHandler(ILogger<CtxcDiffHandler> logger) => _logger = logger;

    public async Task<int> HandleAsync(string left, string right, string format, string? outFile)
    {
        try
        {
            // Baseline: compare evidence.index.json files
            var leftIdx = Path.Combine(left, "evidence.index.json");
            var rightIdx = Path.Combine(right, "evidence.index.json");
            var leftExists = File.Exists(leftIdx);
            var rightExists = File.Exists(rightIdx);
            var added = new List<string>();
            var removed = new List<string>();
            var changed = new List<string>();
            var leftMap = new Dictionary<string, string>();
            var rightMap = new Dictionary<string, string>();

            if (leftExists)
            {
                var json = await File.ReadAllTextAsync(leftIdx);
                try
                {
                    using var doc = JsonDocument.Parse(json);
                    foreach (var el in doc.RootElement.EnumerateArray())
                    {
                        var ek = el.GetProperty("evidenceKey").GetString() ?? string.Empty;
                        var er = el.GetProperty("evidenceRevision").GetString() ?? string.Empty;
                        leftMap[ek] = er;
                    }
                }
                catch
                {
                    _logger.LogWarning("Left evidence.index.json not in expected array form; diff may be empty");
                }
            }
            if (rightExists)
            {
                var json = await File.ReadAllTextAsync(rightIdx);
                try
                {
                    using var doc = JsonDocument.Parse(json);
                    foreach (var el in doc.RootElement.EnumerateArray())
                    {
                        var ek = el.GetProperty("evidenceKey").GetString() ?? string.Empty;
                        var er = el.GetProperty("evidenceRevision").GetString() ?? string.Empty;
                        rightMap[ek] = er;
                    }
                }
                catch
                {
                    _logger.LogWarning("Right evidence.index.json not in expected array form; diff may be empty");
                }
            }

            foreach (var ek in rightMap.Keys)
            {
                if (!leftMap.ContainsKey(ek)) added.Add(ek);
                else if (leftMap[ek] != rightMap[ek]) changed.Add(ek);
            }
            foreach (var ek in leftMap.Keys)
            {
                if (!rightMap.ContainsKey(ek)) removed.Add(ek);
            }

            if (format.Equals("json", StringComparison.OrdinalIgnoreCase))
            {
                var payload = new { added, removed, changed };
                var text = JsonSerializer.Serialize(payload, new JsonSerializerOptions { WriteIndented = true });
                if (outFile is not null) await File.WriteAllTextAsync(outFile, text);
                else Console.WriteLine(text);
            }
            else
            {
                var sb = new StringBuilder();
                sb.AppendLine("# Context Diff");
                sb.AppendLine("## Added EK");
                foreach (var ek in added.OrderBy(s => s, StringComparer.Ordinal)) sb.AppendLine("- " + ek);
                sb.AppendLine("## Removed EK");
                foreach (var ek in removed.OrderBy(s => s, StringComparer.Ordinal)) sb.AppendLine("- " + ek);
                sb.AppendLine("## Changed ER");
                foreach (var ek in changed.OrderBy(s => s, StringComparer.Ordinal)) sb.AppendLine("- " + ek);
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
