using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Core.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Engine;

public interface ICompilerEngine
{
    Task<int> CompileAsync(CompileRequest request, CancellationToken ct);
}

public sealed record CompileRequest(string InputPath, string OutputPath, string Name, bool Clean, CompileOptions? Options = null);

public sealed class CompilerEngine(
    ILogger<CompilerEngine> logger,
    IGlobalPipelineRunner globalPipelineRunner,
    IFileSystem fs,
    IHasher hasher,
    IModulesRegistry modules,
    ICtxcConfigProvider configProvider,
    IConfigLocator configLocator,
    IDocumentPipelineRunner documentPipelineRunner,
    IReasoningIr reasoningIr,
    IGuardian guardian,
    IOutput output
) : ICompilerEngine
{
    public async Task<int> CompileAsync(CompileRequest request, CancellationToken ct)
    {
        CompileOptions options = request.Options ?? new CompileOptions();
        string? configPath = configLocator.Locate(request.InputPath, options.ConfigPath, request.Name);
        ICtxcConfig cfg = configProvider.GetConfigOrDefault(configPath);
        logger.LogInformation("Compile requested. Input={Input} Output={Output}", request.InputPath, request.OutputPath);

        if (options.InlineViews == null)
        {
            options = options with
            {
                InlineViews = cfg.Views?.Inline ?? true
            };
        }
        DocumentsContext documentsContext = new() { RootPath = request.InputPath };
        await documentPipelineRunner.RunAsync(documentsContext, ct);

        guardian.Load(documentsContext);

        IReadOnlyList<IPipelineFinding> findings = guardian.Findings;
        if (findings.Any(f => f.Action == FindingAction.Block && f.Severity == FindingSeverity.Critical))
        {
            return 2;
        }

        foreach (IDocumentContext r in documentsContext.Documents)
        {
            foreach (IFragment f in r.Fragments)
            {
                reasoningIr.Add(f);
            }
        }

        await globalPipelineRunner.RunAsync(request.InputPath, request.OutputPath, request.Clean, reasoningIr, findings, options, output, ct);
        return 0;
    }
}
