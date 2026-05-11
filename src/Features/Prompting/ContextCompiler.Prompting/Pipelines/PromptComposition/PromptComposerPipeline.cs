using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Events;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Prompting.Pipelines.PromptComposition;

public sealed class PromptComposerPipeline(
    ILogger<PromptComposerPipeline> logger,
    IPrompt prompt,
    IModulesRegistry modules,
    IServiceProvider serviceProvider,
    IPromptComposerRunContextBuilder runContextBuilder,
    IPipelineEventPublisher pipelineEventPublisher) : IGlobalPipelineModule, IPipeline
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("pipelines.promptcomposer", GlobalPipelineModuleKinds.OutputComposition, priority: 10);

    public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        // Récupérer tous les modules PromptComposer
        IOrderedEnumerable<IPromptComposerModule> orderedModules = serviceProvider.GetServices<IPromptComposerModule>().OrderBy(c => c.Metadata.Priority);

        logger.LogDebug("Will run prompt composer pipeline with {ModuleCount} modules in order:", orderedModules.Count());
        int index = 1;
        foreach (IPromptComposerModule module in orderedModules)
        {
            logger.LogDebug("{Index}: {ModuleName} (Priority: {ModulePriority})",
                index, module.Metadata.Id, module.Metadata.Priority);
            index++;
        }

        // Exécuter séquentiellement tous les modules PromptComposer
        foreach (IPromptComposerModule module in orderedModules)
        {
            cancellationToken.ThrowIfCancellationRequested();

            logger.LogInformation(
                "Running prompt composer module: {ModuleName} (Priority: {ModulePriority})",
                module.Metadata.Id,
                module.Metadata.Priority);

            IPromptComposerRunContext innerRunContext = runContextBuilder
                .InitNew()
                .WithPipeline(this)
                .WithParent(context)
                .WithPrompt(prompt)
                .Build();

            await pipelineEventPublisher.PublishPhaseAsync(innerRunContext,
                                                           module.Metadata.Kind.ToString(),
                                                           module.Metadata.Id,
                                                           async () =>
                                                           {
                                                               IResult<IPromptComposerRunResult> result = await module.Run(innerRunContext, cancellationToken);

                                                               if (result is IFailureResult<IPromptComposerRunResult> failureResult)
                                                               {
                                                                   logger.LogError(
                                                                       "Prompt composer module {ModuleName} failed: {Message}",
                                                                       module.Metadata.Id,
                                                                       failureResult.Message);
                                                               }
                                                           },
                                                           cancellationToken);
        }

        logger.LogInformation("Prompt composer pipeline completed with {ModuleCount} modules executed", orderedModules.Count());

        return await context.Success();
    }
}
