using System.Text.Json;

using ContextCompiler.Abstractions.Models;
using ContextCompiler.Core.Engine;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Host.Cli.Handlers;

internal sealed class CtxcCompileHandler : ICtxcCompileHandler
{
    private readonly ICompilerEngine _engine;
    private readonly ILogger<CtxcCompileHandler> _logger;
    private JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public CtxcCompileHandler(ICompilerEngine engine, ILogger<CtxcCompileHandler> logger)
    {
        _engine = engine;
        _logger = logger;
    }

    public async Task<int> HandleAsync(string input, string output, int maxChars, string? views, bool disableNonCritical, string? configPath, bool json)
    {
        try
        {
            var rc = await _engine.CompileAsync(new CompileRequest(input, output, new CompileOptions(MaxCharacters: maxChars)), CancellationToken.None);
            if (json)
            {
                var summary = new
                {
                    exitCode = rc,
                    inputPath = input,
                    outputPath = output,
                    artifacts = new[] { "prompt.context.md", "evidence.index.json", "reasoning.graph.json" },
                    views = new[] { "default" }
                };

                Console.WriteLine(JsonSerializer.Serialize(summary, jsonSerializerOptions));
            }
            else
            {
                _logger.LogInformation("Compiled {Input} -> {Output} (rc={Rc})", input, output, rc);
            }
            return rc;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Internal error");
            return 1;
        }
    }
}
