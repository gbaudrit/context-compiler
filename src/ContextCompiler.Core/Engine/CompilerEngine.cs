using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Core.Guards;
using ContextCompiler.Core.Pipelines;
using ContextCompiler.Core.ReasoningIR;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Engine;

public interface ICompilerEngine
{
    Task<int> CompileAsync(CompileRequest request, CancellationToken ct);
}

public sealed record CompileRequest(string InputPath, string OutputPath, string Name, CompileOptions? Options = null);

public sealed class CompilerEngine(
    ILogger<CompilerEngine> logger,
    IFileSystem fs,
    IHasher hasher,
    IPluginRegistry plugins,
    ICtxcConfigProvider configProvider,
    IConfigLocator configLocator,
    IDocumentPipelineRunner documentPipelineRunner,
    IReasoningIr reasoningIr,
    IGuardian guardian
) : ICompilerEngine
{
    public async Task<int> CompileAsync(CompileRequest request, CancellationToken ct)
    {
        var options = request.Options ?? new CompileOptions();
        var configPath = configLocator.Locate(request.InputPath, options.ConfigPath, request.Name);
        CtxcConfig cfg = configProvider.GetConfigOrDefault(configPath);
        logger.LogInformation("Compile requested. Input={Input} Output={Output}", request.InputPath, request.OutputPath);

        if (options.InlineViews == null)
        {
            options = options with
            {
                InlineViews = cfg.Views?.Inline ?? true
            };
        }

        var docResults = await documentPipelineRunner.RunAsync(request.InputPath, ct);

        guardian.Load(docResults);

        var findings = guardian.Findings;
        if (findings.Any(f => f.Action == GuardActionKind.Block && f.Severity == GuardSeverity.Critical))
            return 2;

        foreach (var r in docResults)
            foreach (var f in r.Fragments)
                reasoningIr.Add(f);

        var globalRunner = new GlobalPipelineRunner(logger, fs, hasher, plugins, cfg, guardian);
        await globalRunner.RunAsync(request.InputPath, request.OutputPath, reasoningIr, findings, options, plugins.Outputs, ct);
        return 0;
    }
}
