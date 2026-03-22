using System.Text.Json;

using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Core.Engine;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Handlers;

public record CtxcCompileCommandLine(
    string Input,
    string Output,
    string Name,
    int MaxChars,
    string? Views,
    bool? NoInlineViews,
    bool? NoGuards,
    string? ConfigPath,
    bool Json,
    bool Clean);

internal sealed class CtxcCompileHandler(ICompilerEngine engine, IOutputContext outputContext, ILogger<CtxcCompileHandler> logger) : ICtxcCompileHandler
{
    private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };


    public async Task<int> HandleAsync(CtxcCompileCommandLine compileCommandLine)
    {
        try
        {
            outputContext.OutputPath = compileCommandLine.Output;

            int rc = await engine.CompileAsync(new CompileRequest(compileCommandLine.Input,
                                                                   compileCommandLine.Output,
                                                                   compileCommandLine.Name,
                                                                   compileCommandLine.Clean,
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
                logger.LogInformation("Compiled {Input} -> {Output} (rc={Rc})", compileCommandLine.Input, compileCommandLine.Output, rc);
            }
            return rc;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return 1;
        }
    }
}
