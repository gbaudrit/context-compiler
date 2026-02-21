using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines;

public sealed record GlobalCompileOutputs(
    IReadOnlyDictionary<string, string> Artifacts,
    GraphModel Graph,
    IReadOnlyList<IPipelineFinding> Findings
);

public sealed class GlobalPipelineRunner(
    ILogger<GlobalPipelineRunner> logger,
    IDocumentContextBuilder docCtxBuilder,
    IFileSystem fs,
    IHasher hasher,
    IModulesRegistry modules,
    ICtxcConfigProvider cfgProvider,
    IPrompt prompt,
    IOutput output,
    IGuardian guardian) : IGlobalPipelineRunner
{

    public async ValueTask RunAsync(
        string rootPath,
        string outputPath,
        bool cleanOutput,
        IReasoningIr ir,
        IReadOnlyList<IPipelineFinding> findings,
        CompileOptions options,
        IOutput output,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        fs.EnsureDirectory(outputPath, cleanOutput);

        ICtxcConfig cfg = cfgProvider.Current;

        await Task.WhenAll(modules.GlobalPipelineModules.OrderBy(c => c.Metadata.Kind).Select(async p =>
        {
            logger.LogInformation("Running global pipeline module: {ModuleName} (Kind: {ModuleKind}, Priority: {ModulePriority})",
                p.Metadata.Id, p.Metadata.Kind, p.Metadata.Priority);
            await p.Run(ct);
        }));
    }
}
