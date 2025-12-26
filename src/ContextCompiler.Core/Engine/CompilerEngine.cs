using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Core.Pipelines;
using ContextCompiler.Core.ReasoningIR;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Engine;

public interface ICompilerEngine
{
    Task<int> CompileAsync(CompileRequest request, CancellationToken ct);
}

public sealed record CompileRequest(string InputPath, string OutputPath, CompileOptions? Options = null);

public sealed class CompilerEngine(
    ILogger<CompilerEngine> logger,
    IFileSystem fs,
    IHasher hasher,
    IPluginRegistry plugins
) : ICompilerEngine
{
    public async Task<int> CompileAsync(CompileRequest request, CancellationToken ct)
    {
        var options = request.Options ?? new CompileOptions();
        logger.LogInformation("Compile requested. Input={Input} Output={Output}", request.InputPath, request.OutputPath);

        var docRunner = new DocumentPipelineRunner(logger, fs, hasher, plugins);
        var docResults = await docRunner.RunAsync(request.InputPath, ct);

        var findings = docResults.SelectMany(r => r.Findings).ToList();
        if (findings.Any(f => f.Action == GuardActionKind.Block && f.Severity == GuardSeverity.Critical))
            return 2;

        var ir = new ReasoningIr();
        foreach (var r in docResults)
            foreach (var f in r.Fragments)
                ir.Add(f);

        var globalRunner = new GlobalPipelineRunner(logger, fs, hasher, plugins);
        await globalRunner.RunAsync(request.InputPath, request.OutputPath, ir, findings, options, ct);
        return 0;
    }
}
