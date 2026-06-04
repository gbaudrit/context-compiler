using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Pipelines.Events;
using ContextCompiler.Abstractions.Pipelines.Prepare;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Pipelines.Prepare;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Prepare;

public sealed class PreparePipeline(
    ILogger<PreparePipeline> logger,
    IModulesRegistry modules,
    IPreparePipelineRunContextBuilder runContextBuilder,
    IPipelineEventPublisher pipelineEventPublisher) : IPreparePipeline
{
    public string CurrentPhaseKey { get; private set; } = string.Empty;

    public async ValueTask RunAsync(PrepareRequest request, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(request);
        ct.ThrowIfCancellationRequested();

        IOrderedEnumerable<IPreparePipelineModule> orderedModules = modules.PreparePipelineModules.OrderBy(m => m.Metadata.Kind);

        logger.LogDebug("Will running prepare pipeline with {ModuleCount} modules in order :", orderedModules.Count());
        int index = 1;
        foreach (IPreparePipelineModule module in orderedModules)
        {
            logger.LogDebug("{Index}: {ModuleName} (Kind: {ModuleKind} ({ModuleKindValue}), Priority: {ModulePriority})",
                index, module.Metadata.Id, module.Metadata.Kind, module.Metadata.Kind.ToString("D"), module.Metadata.Priority);
            index++;
        }

        IPreparePipelineRunContext runContext = runContextBuilder
            .InitNew()
            .WithPipeline(this)
            .WithPhaseKey(string.Empty)
            .WithRequest(request)
            .Build();

        IOrderedEnumerable<IGrouping<int, IPreparePipelineModule>> groups = orderedModules
            .GroupBy(m => (int)m.Metadata.Kind)
            .OrderBy(g => g.Key);

        foreach (IGrouping<int, IPreparePipelineModule> group in groups)
        {
            logger.LogInformation("Running prepare pipeline group Kind={Kind} with {Count} modules",
                group.Key, group.Count());

            CurrentPhaseKey = group.First().Metadata.Kind.ToString();

            await Task.WhenAll(group.OrderBy(x => x.Metadata.Priority).Select(async module =>
            {
                logger.LogInformation(
                    "Running prepare pipeline module: {ModuleName} (Kind: {ModuleKind}, Priority: {ModulePriority})",
                    module.Metadata.Id,
                    module.Metadata.Kind,
                    module.Metadata.Priority);

                _ = await pipelineEventPublisher.PublishPhaseAsync(runContext,
                                                               module.Metadata.Kind.ToString(),
                                                               module.Metadata.Id,
                                                               async () => await module.Run(runContext, ct),
                                                               ct);
            }));
        }
    }
}
