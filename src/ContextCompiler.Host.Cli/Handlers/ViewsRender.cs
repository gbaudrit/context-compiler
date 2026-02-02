using Microsoft.Extensions.Logging;

namespace ContextCompiler.Host.Cli.Handlers;

internal sealed class CtxcViewsRenderHandler(ILogger<CtxcViewsRenderHandler> logger) : ICtxcViewsRenderHandler
{
    public async Task<int> HandleAsync(string id, string input, string? outFile)
    {
        try
        {
            string path = Path.Combine(input, $"view.{id}.md");
            if (!File.Exists(path))
            {
                logger.LogError("View not found: {Id}", id);
                return 1;
            }
            string content = await File.ReadAllTextAsync(path);
            if (outFile is not null)
            {
                await File.WriteAllTextAsync(outFile, content);
            }
            else
            {
                Console.WriteLine(content);
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
