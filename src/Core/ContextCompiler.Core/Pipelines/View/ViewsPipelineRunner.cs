using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.View;

public sealed class ViewsPipelineRunner(ILogger<GlobalPipeline> logger,
                                        IOutput output,
                                        IConfigProvider ctxcConfig,
                                        IModulesRegistry modules,
                                        IReasoningIr ir) : IGlobalPipelineModule
{

    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("views", GlobalPipelineModuleKinds.OutputProjection, priority: 10);

    public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        IOrderedEnumerable<IViewModule> orderedModules = modules.Views.OrderBy(c => c.Metadata.Kind);

        logger.LogDebug("Will running view pipeline with {ModuleCount} modules in order :", orderedModules.Count());
        int index = 1;
        foreach (IViewModule module in orderedModules)
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
        IOrderedEnumerable<IGrouping<int, IViewModule>> groups = orderedModules
            .GroupBy(m => (int)m.Metadata.Kind)
            .OrderBy(g => g.Key);

        foreach (IGrouping<int, IViewModule> group in groups)
        {
            logger.LogInformation("Running view pipeline group Kind={Kind} with {Count} modules",
                group.Key, group.Count());

            await Task.WhenAll(group.OrderBy(x => x.Metadata.Priority).Select(async module =>
            {
                logger.LogInformation(
                    "Running global pipeline module: {ModuleName} (Priority: {ModulePriority})",
                    module.Metadata.Id,
                    module.Metadata.Priority);

                IReadOnlyList<IViewResult> results = await module.Run(new ViewContext(ctxcConfig.Current.Views, ir), cancellationToken);
                foreach (IViewResult result in results)
                {
                    output.AddArtifact((builder) =>
                    {
                        return builder.WithFileName(result.Filename)
                                      .WithContent(result.Content)
                                      .WithGeneratedBy(GetType());
                    });
                }
            }));
        }

        return await context.Success();
    }
}
