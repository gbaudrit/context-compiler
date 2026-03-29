using System.Text;
using System.Text.Json;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Handlers;

internal sealed class CtxcDiffHandler(ILogger<CtxcDiffHandler> logger) : ICtxcDiffHandler
{
    private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public async Task<int> HandleAsync(string left, string right, string format, string? outFile)
    {
        try
        {
            // Baseline: compare evidence.index.json files
            string leftIdx = Path.Combine(left, "evidence.index.json");
            string rightIdx = Path.Combine(right, "evidence.index.json");
            bool leftExists = File.Exists(leftIdx);
            bool rightExists = File.Exists(rightIdx);
            List<string> added = [];
            List<string> removed = [];
            List<string> changed = [];
            Dictionary<string, string> leftMap = [];
            Dictionary<string, string> rightMap = [];

            if (leftExists)
            {
                string json = await File.ReadAllTextAsync(leftIdx);
                try
                {
                    using JsonDocument doc = JsonDocument.Parse(json);
                    foreach (JsonElement el in doc.RootElement.EnumerateArray())
                    {
                        string ek = el.GetProperty("evidenceKey").GetString() ?? string.Empty;
                        string er = el.GetProperty("evidenceRevision").GetString() ?? string.Empty;
                        leftMap[ek] = er;
                    }
                }
                catch
                {
                    logger.LogWarning("Left evidence.index.json not in expected array form; diff may be empty");
                }
            }
            if (rightExists)
            {
                string json = await File.ReadAllTextAsync(rightIdx);
                try
                {
                    using JsonDocument doc = JsonDocument.Parse(json);
                    foreach (JsonElement el in doc.RootElement.EnumerateArray())
                    {
                        string ek = el.GetProperty("evidenceKey").GetString() ?? string.Empty;
                        string er = el.GetProperty("evidenceRevision").GetString() ?? string.Empty;
                        rightMap[ek] = er;
                    }
                }
                catch
                {
                    logger.LogWarning("Right evidence.index.json not in expected array form; diff may be empty");
                }
            }

            foreach (string ek in rightMap.Keys)
            {
                if (!leftMap.TryGetValue(ek, out string? value))
                {
                    added.Add(ek);
                }
                else if (value != rightMap[ek])
                {
                    changed.Add(ek);
                }
            }
            foreach (string ek in leftMap.Keys)
            {
                if (!rightMap.ContainsKey(ek))
                {
                    removed.Add(ek);
                }
            }

            if (format.Equals("json", StringComparison.OrdinalIgnoreCase))
            {
                var payload = new { added, removed, changed };
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
                _ = sb.AppendLine("# Context Diff");
                _ = sb.AppendLine("## Added EK");
                foreach (string? ek in added.OrderBy(s => s, StringComparer.Ordinal))
                {
                    _ = sb.AppendLine("- " + ek);
                }

                _ = sb.AppendLine("## Removed EK");
                foreach (string? ek in removed.OrderBy(s => s, StringComparer.Ordinal))
                {
                    _ = sb.AppendLine("- " + ek);
                }

                _ = sb.AppendLine("## Changed ER");
                foreach (string? ek in changed.OrderBy(s => s, StringComparer.Ordinal))
                {
                    _ = sb.AppendLine("- " + ek);
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
            logger.LogError(ex, "Internal error");
            return 1;
        }
    }
}
