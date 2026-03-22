using System.Text.Json;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Handlers;

internal sealed class CtxcViewsListHandler(ILogger<CtxcViewsListHandler> logger) : ICtxcViewsListHandler
{
    private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public Task<int> HandleAsync(string input, bool json)
    {
        try
        {
            IEnumerable<string> files = Directory.Exists(input)
                ? Directory.EnumerateFiles(input, "view.*.md", SearchOption.TopDirectoryOnly)
                : [];
            string[] ids = [.. files.Select(f => Path.GetFileName(f))
                           .Select(n => n[5..^3]) // strip view. + .md
                           .OrderBy(s => s, StringComparer.Ordinal)];
            if (json)
            {
                Console.WriteLine(JsonSerializer.Serialize(ids, jsonSerializerOptions));
            }
            else
            {
                foreach (string? id in ids)
                {
                    Console.WriteLine(id);
                }
            }
            return Task.FromResult(0);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return Task.FromResult(1);
        }
    }
}
