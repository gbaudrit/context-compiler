using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Abstractions.Pipelines.Events;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines;

public sealed record GlobalCompileOutputs(
    IReadOnlyDictionary<string, string> Artifacts,
    GraphModel Graph,
    IReadOnlyList<IPipelineFinding> Findings
);

public sealed class GlobalPipeline(
    ILogger<GlobalPipeline> logger,
    IInputItemContextBuilder docCtxBuilder,
    IFileSystem fs,
    IHasher hasher,
    IModulesRegistry modules,
    IConfigProvider cfgProvider,
    IOutput output,
    IGuardian guardian,
    IGlobalPipelineRunContextBuilder globalPipelineRunContextBuilder,
    IPipelineEventPublisher pipelineEventPublisher) : IGlobalPipeline
{

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

        IOrderedEnumerable<IGlobalPipelineModule> orderedModules = modules.GlobalPipelineModules.OrderBy(c => c.Metadata.Kind);

        logger.LogDebug("Will running global pipeline with {ModuleCount} modules in order :", orderedModules.Count());
        int index = 1;
        foreach (IGlobalPipelineModule module in orderedModules)
        {
            logger.LogDebug("{Index}: {ModuleName} (Kind: {ModuleKind} ({ModuleKindValue}), Priority: {ModulePriority})",
                index, module.Metadata.Id, module.Metadata.Kind, module.Metadata.Kind.ToString("D"), module.Metadata.Priority);
            index++;
        }

        //await Task.WhenAll(orderedModules.Select(async p =>
        //{
        //    logger.LogInformation("Running global pipeline module: {ModuleName} (Kind: {ModuleKind}, Priority: {ModulePriority})",
        //        p.Metadata.Id, p.Metadata.Kind, p.Metadata.Priority);
        //    await p.Run(ct);
        //}));

        // Exécution par groupe de Kind, chaque groupe en parallèle,
        // mais les groupes s'exécutent séquentiellement
        IOrderedEnumerable<IGrouping<int, IGlobalPipelineModule>> groups = orderedModules
            .GroupBy(m => (int)m.Metadata.Kind)
            .OrderBy(g => g.Key);

        foreach (IGrouping<int, IGlobalPipelineModule> group in groups)
        {
            logger.LogInformation("Running global pipeline group Kind={Kind} with {Count} modules",
                group.Key, group.Count());

            await Task.WhenAll(group.OrderBy(x => x.Metadata.Priority).Select(async module =>
            {
                logger.LogInformation(
                    "Running global pipeline module: {ModuleName} (Kind: {ModuleKind}, Priority: {ModulePriority})",
                    module.Metadata.Id,
                    module.Metadata.Kind,
                    module.Metadata.Priority);

                IGlobalPipelineRunContext moduleContext = globalPipelineRunContextBuilder
                    .InitNew()
                    .WithPipeline(this)
                    .Build();

                _ = await pipelineEventPublisher.PublishPhaseAsync(this,
                                                               module.Metadata.Kind.ToString(),
                                                               module.Metadata.Id,
                                                               async () => await module.Run(moduleContext, ct),
                                                               ct);
            }));
        }
    }
}
