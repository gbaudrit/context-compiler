using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Host.Cli.Handlers;

internal sealed class CtxcGraphExportHandler : ICtxcGraphExportHandler
{
    private readonly ILogger<CtxcGraphExportHandler> _logger;
    public CtxcGraphExportHandler(ILogger<CtxcGraphExportHandler> logger) => _logger = logger;

    public async Task<int> HandleAsync(string input, string format, string? outFile)
    {
        try
        {
            var jsonPath = Path.Combine(input, "reasoning.graph.json");
            if (!File.Exists(jsonPath))
            {
                _logger.LogError("reasoning.graph.json not found in {input}", input);
                return 1;
            }
            var json = await File.ReadAllTextAsync(jsonPath);

            if (string.Equals(format, "json", StringComparison.OrdinalIgnoreCase))
            {
                if (outFile is not null) await File.WriteAllTextAsync(outFile, json);
                else Console.WriteLine(json);
                return 0;
            }

            // Baseline simple converter: dot/mermaid trivial
            if (string.Equals(format, "dot", StringComparison.OrdinalIgnoreCase))
            {
                var text = "digraph reasoning {\n  // exporter stub\n}";
                if (outFile is not null) await File.WriteAllTextAsync(outFile, text);
                else Console.WriteLine(text);
                return 0;
            }
            if (string.Equals(format, "mermaid", StringComparison.OrdinalIgnoreCase))
            {
                var text = "graph TD\n  %% exporter stub";
                if (outFile is not null) await File.WriteAllTextAsync(outFile, text);
                else Console.WriteLine(text);
                return 0;
            }

            _logger.LogError("Unsupported format: {format}", format);
            return 1;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Internal error");
            return 1;
        }
    }
}
