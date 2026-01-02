using Microsoft.Extensions.Logging;

namespace ContextCompiler.Host.Cli.Handlers;

internal sealed class CtxcViewsRenderHandler : ICtxcViewsRenderHandler
{
    private readonly ILogger<CtxcViewsRenderHandler> _logger;
    public CtxcViewsRenderHandler(ILogger<CtxcViewsRenderHandler> logger) => _logger = logger;

    public async Task<int> HandleAsync(string id, string input, string? outFile)
    {
        try
        {
            var path = Path.Combine(input, $"view.{id}.md");
            if (!File.Exists(path))
            {
                _logger.LogError("View not found: {Id}", id);
                return 1;
            }
            var content = await File.ReadAllTextAsync(path);
            if (outFile is not null) await File.WriteAllTextAsync(outFile, content);
            else Console.WriteLine(content);
            return 0;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Internal error");
            return 1;
        }
    }
}
