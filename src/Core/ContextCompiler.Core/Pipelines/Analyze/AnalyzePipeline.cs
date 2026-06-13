using ContextCompiler.Abstractions.Models.Analyze;
using ContextCompiler.Abstractions.Pipelines.Analyze;
using ContextCompiler.Abstractions.Pipelines.Events;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Pipelines.Analyze;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Analyze;

public sealed class AnalyzePipeline(
    ILogger<AnalyzePipeline> logger,
    IModulesRegistry modules,
    IAnalyzePipelineRunContextBuilder runContextBuilder,
    IPipelineEventPublisher pipelineEventPublisher) : IAnalyzePipeline
{
    public string CurrentPhaseKey { get; private set; } = string.Empty;

    public async ValueTask RunAsync(AnalyzeRequest request, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(request);
        ct.ThrowIfCancellationRequested();

        IOrderedEnumerable<IAnalyzePipelineModule> orderedModules = modules.AnalyzePipelineModules.OrderBy(m => m.Metadata.Kind);

        IAnalyzePipelineRunContext runContext = runContextBuilder
            .InitNew()
            .WithPipeline(this)
            .WithPhaseKey(string.Empty)
            .WithRequest(request)
            .Build();

        IOrderedEnumerable<IGrouping<int, IAnalyzePipelineModule>> groups = orderedModules
            .GroupBy(m => (int)m.Metadata.Kind)
            .OrderBy(g => g.Key);

        foreach (IGrouping<int, IAnalyzePipelineModule> group in groups)
        {
            logger.LogInformation("Running analyze pipeline group Kind={Kind} with {Count} modules", group.Key, group.Count());
            CurrentPhaseKey = group.First().Metadata.Kind.ToString();

            await Task.WhenAll(group.OrderBy(x => x.Metadata.Priority).Select(async module =>
            {
                _ = await pipelineEventPublisher.PublishPhaseAsync(
                    runContext,
                    module.Metadata.Kind.ToString(),
                    module.Metadata.Id,
                    async () => await module.Run(runContext, ct),
                    ct);
            }));
        }
    }
}
