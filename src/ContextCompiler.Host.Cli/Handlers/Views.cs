using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Host.Cli.Handlers;

internal sealed class CtxcViewsListHandler : ICtxcViewsListHandler
{
    private readonly ILogger<CtxcViewsListHandler> _logger;
    public CtxcViewsListHandler(ILogger<CtxcViewsListHandler> logger) => _logger = logger;

    public Task<int> HandleAsync(string input, bool json)
    {
        try
        {
            var files = Directory.Exists(input)
                ? Directory.EnumerateFiles(input, "view.*.md", SearchOption.TopDirectoryOnly)
                : Enumerable.Empty<string>();
            var ids = files.Select(f => Path.GetFileName(f))
                           .Select(n => n.Substring(5, n.Length - 8)) // strip view. + .md
                           .OrderBy(s => s, StringComparer.Ordinal)
                           .ToArray();
            if (json)
            {
                Console.WriteLine(JsonSerializer.Serialize(ids, new JsonSerializerOptions { WriteIndented = true }));
            }
            else
            {
                foreach (var id in ids) Console.WriteLine(id);
            }
            return Task.FromResult(0);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Internal error");
            return Task.FromResult(1);
        }
    }
}
