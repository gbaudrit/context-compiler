using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Compile;
using ContextCompiler.Abstractions.Sources;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.DevTools.Modules.SourcesConsole;

public sealed class SourcesConsoleModule(
    ISourcesProvider sourcesProvider,
    ILogger<SourcesConsoleModule> logger) : ICompilePipelineModule
{
    public ModuleMetadata Metadata => ICompilePipelineModule.Meta("devtools.sources-console", CompilePipelineModuleKinds.PostProcessing, priority: 1000);

    public Task<IResult<ICompilePipelineRunResult>> Run(ICompilePipelineRunContext context, CancellationToken cancellationToken)
    {
        IReadOnlyList<ISource> sources = sourcesProvider.GetAll();

        if (sources.Count == 0)
        {
            return context.Success();
        }

        logger.LogInformation("=== Sources Console DevTools ===");
        logger.LogInformation("Total sources found: {Count}", sources.Count);

        foreach (ISource source in sources)
        {
            cancellationToken.ThrowIfCancellationRequested();

            logger.LogInformation("--- Source ---");
            logger.LogInformation("  RootPath: {RootPath}", source.RootPath);
            logger.LogInformation("  OptionsKey: {OptionsKey}", source.OptionsKey);
            logger.LogInformation("  Includes: {Includes}", string.Join(", ", source.Includes));
            logger.LogInformation("  Excludes: {Excludes}", string.Join(", ", source.Excludes));
            logger.LogInformation("  Tags: {Tags}", string.Join(", ", source.Tags));
        }

        logger.LogInformation("=== End Sources Console ===");

        return context.Success();
    }
}
