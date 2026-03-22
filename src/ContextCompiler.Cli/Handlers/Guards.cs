using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Handlers;

internal sealed class CtxcGuardsReportHandler(ILogger<CtxcGuardsReportHandler> logger) : ICtxcGuardsReportHandler
{
    public async Task<int> HandleAsync(string input, string format, string? outFile)
    {
        try
        {
            string md = Path.Combine(input, "security.report.md");
            if (!File.Exists(md))
            {
                logger.LogWarning("No security.report.md found");
                return 0;
            }

            string content = await File.ReadAllTextAsync(md);
            if (string.Equals(format, "json", StringComparison.OrdinalIgnoreCase))
            {
                // Phase 1: no structured JSON; wrap markdown in a JSON envelope
                string payload = "{\"format\":\"md\",\"content\":" + System.Text.Json.JsonSerializer.Serialize(content) + "}";
                if (outFile is not null)
                {
                    await File.WriteAllTextAsync(outFile, payload);
                }
                else
                {
                    Console.WriteLine(payload);
                }
            }
            else
            {
                if (outFile is not null)
                {
                    await File.WriteAllTextAsync(outFile, content);
                }
                else
                {
                    Console.WriteLine(content);
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
