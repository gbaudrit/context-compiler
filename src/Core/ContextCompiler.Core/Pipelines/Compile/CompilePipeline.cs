using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Compile;
using ContextCompiler.Abstractions.Pipelines.Events;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Compile;

public sealed class CompilePipeline(
    ILogger<CompilePipeline> logger,
    IInputItemContextBuilder docCtxBuilder,
    IFileSystem fs,
    IHasher hasher,
    IModulesRegistry modules,
    IConfigProvider cfgProvider,
    IOutput output,
    IGuardian guardian,
    ICompilePipelineRunContextBuilder compilePipelineRunContextBuilder,
    IPipelineEventPublisher pipelineEventPublisher) : ICompilePipeline
{

    public string CurrentPhaseKey { get; private set; } = string.Empty;


    public async ValueTask RunAsync(
        string rootPath,
        string outputPath,
        bool cleanOutput,
        IOutput output,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        fs.EnsureDirectory(outputPath, cleanOutput);

        IRootConfigSection cfg = cfgProvider.Current;

        IOrderedEnumerable<ICompilePipelineModule> orderedModules = modules.CompilePipelineModules.OrderBy(c => c.Metadata.Kind);

        logger.LogDebug("Will running compile pipeline with {ModuleCount} modules in order :", orderedModules.Count());
        int index = 1;
        foreach (ICompilePipelineModule module in orderedModules)
        {
            logger.LogDebug("{Index}: {ModuleName} (Kind: {ModuleKind} ({ModuleKindValue}), Priority: {ModulePriority})",
                index, module.Metadata.Id, module.Metadata.Kind, module.Metadata.Kind.ToString("D"), module.Metadata.Priority);
            index++;
        }

        //await Task.WhenAll(orderedModules.Select(async p =>
        //{
        //    logger.LogInformation("Running compile pipeline module: {ModuleName} (Kind: {ModuleKind}, Priority: {ModulePriority})",
        //        p.Metadata.Id, p.Metadata.Kind, p.Metadata.Priority);
        //    await p.Run(ct);
        //}));

        // Exécution par groupe de Kind, chaque groupe en parallèle,
        // mais les groupes s'exécutent séquentiellement
        IOrderedEnumerable<IGrouping<int, ICompilePipelineModule>> groups = orderedModules
            .GroupBy(m => (int)m.Metadata.Kind)
            .OrderBy(g => g.Key);

        foreach (IGrouping<int, ICompilePipelineModule> group in groups)
        {
            logger.LogInformation("Running compile pipeline group Kind={Kind} with {Count} modules",
                group.Key, group.Count());

            CurrentPhaseKey = group.First().Metadata.Kind.ToString();

            await Task.WhenAll(group.OrderBy(x => x.Metadata.Priority).Select(async module =>
            {
                logger.LogInformation(
                    "Running compile pipeline module: {ModuleName} (Kind: {ModuleKind}, Priority: {ModulePriority})",
                    module.Metadata.Id,
                    module.Metadata.Kind,
                    module.Metadata.Priority);

                ICompilePipelineRunContext runContext = compilePipelineRunContextBuilder
                    .InitNew()
                    .WithPipeline(this)
                    .WithPhaseKey(module.Metadata.Kind.ToString())
                    .Build();

                _ = await pipelineEventPublisher.PublishPhaseAsync(runContext,
                                                               module.Metadata.Kind.ToString(),
                                                               module.Metadata.Id,
                                                               async () => await module.Run(runContext, ct),
                                                               ct);
            }));
        }
    }
}
