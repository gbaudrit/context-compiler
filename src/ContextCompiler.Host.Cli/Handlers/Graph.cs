using Microsoft.Extensions.Logging;

namespace ContextCompiler.Host.Cli.Handlers;

internal sealed class CtxcGraphExportHandler(ILogger<CtxcGraphExportHandler> logger) : ICtxcGraphExportHandler
{
    public async Task<int> HandleAsync(string input, string format, string? outFile)
    {
        try
        {
            string jsonPath = Path.Combine(input, "reasoning.graph.json");
            if (!File.Exists(jsonPath))
            {
                logger.LogError("reasoning.graph.json not found in {Input}", input);
                return 1;
            }
            string json = await File.ReadAllTextAsync(jsonPath);

            if (string.Equals(format, "json", StringComparison.OrdinalIgnoreCase))
            {
                if (outFile is not null)
                {
                    await File.WriteAllTextAsync(outFile, json);
                }
                else
                {
                    Console.WriteLine(json);
                }

                return 0;
            }

            // Baseline simple converter: dot/mermaid trivial
            if (string.Equals(format, "dot", StringComparison.OrdinalIgnoreCase))
            {
                string text = "digraph reasoning {\n  // exporter stub\n}";
                if (outFile is not null)
                {
                    await File.WriteAllTextAsync(outFile, text);
                }
                else
                {
                    Console.WriteLine(text);
                }

                return 0;
            }
            if (string.Equals(format, "mermaid", StringComparison.OrdinalIgnoreCase))
            {
                string text = "graph TD\n  %% exporter stub";
                if (outFile is not null)
                {
                    await File.WriteAllTextAsync(outFile, text);
                }
                else
                {
                    Console.WriteLine(text);
                }

                return 0;
            }

            logger.LogError("Unsupported format: {Format}", format);
            return 1;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return 1;
        }
    }
}
