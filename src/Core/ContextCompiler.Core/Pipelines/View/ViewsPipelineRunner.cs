using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines.Compile;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Abstractions.Views;
using ContextCompiler.Core.Pipelines.Compile;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.View;

public sealed class ViewsPipelineRunner(ILogger<CompilePipeline> logger,
                                        IOutput output,
                                        IConfigProvider ctxcConfig,
                                        IModulesRegistry modules,
                                        ICompiledContext compiledContext) : ICompilePipelineModule
{

    public ModuleMetadata Metadata => ICompilePipelineModule.Meta("views", CompilePipelineModuleKinds.OutputProjection, priority: 10);

    public async Task<IResult<ICompilePipelineRunResult>> Run(ICompilePipelineRunContext context, CancellationToken cancellationToken)
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
        //    logger.LogInformation("Running compile pipeline module: {ModuleName} (Kind: {ModuleKind}, Priority: {ModulePriority})",
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
                    "Running compile pipeline module: {ModuleName} (Priority: {ModulePriority})",
                    module.Metadata.Id,
                    module.Metadata.Priority);

                IReadOnlyList<IViewResult> results = await module.Run(new ViewContext(ctxcConfig.Current.Views, compiledContext), cancellationToken);
                foreach (IViewResult result in results)
                {
                    output.AddArtifact((builder) =>
                    {
                        return builder.WithName(result.Filename)
                                      .InStore(StoreKeys.Output)
                                      .WithContent(result.Content)
                                      .WithGeneratedBy(GetType());
                    });
                }
            }));
        }

        return await context.Success();
    }
}
