using System.Text.Json;

using ContextCompiler.Abstractions.Models;
using ContextCompiler.Core.Engine;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Host.Cli.Handlers;

public record CtxcCompileCommandLine(
    string Input,
    string Output,
    string Name,
    int MaxChars,
    string? Views,
    bool? NoInlineViews,
    bool? NoGuards,
    string? ConfigPath,
    bool Json);

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

    public async Task<int> HandleAsync(CtxcCompileCommandLine compileCommandLine)
    {
        try
        {
            var rc = await _engine.CompileAsync(new CompileRequest(compileCommandLine.Input,
                                                                   compileCommandLine.Output,
                                                                   compileCommandLine.Name,
                                                                   new CompileOptions(MaxCharacters: compileCommandLine.MaxChars,
                                                                                      InlineViews: compileCommandLine.NoInlineViews ?? !compileCommandLine.NoInlineViews)), CancellationToken.None);
            if (compileCommandLine.Json)
            {
                var summary = new
                {
                    exitCode = rc,
                    inputPath = compileCommandLine.Input,
                    outputPath = compileCommandLine.Output,
                    artifacts = new[] { "prompt.context.md", "evidence.index.json", "reasoning.graph.json" },
                    views = new[] { "default" }
                };

                Console.WriteLine(JsonSerializer.Serialize(summary, jsonSerializerOptions));
            }
            else
            {
                _logger.LogInformation("Compiled {Input} -> {Output} (rc={Rc})", compileCommandLine.Input, compileCommandLine.Output, rc);
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
