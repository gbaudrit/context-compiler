using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.DataPart
{
    internal sealed class DataPartPipelineRunner(IModulesRegistry modules,
                                                 IInputItemContextPatcher inputItemContextPatcher,
                                                 IServiceProvider serviceProvider,
                                                 ILogger<DataPartPipelineRunner> logger) : IInputIngestionPipelineModule
    {

        public InputIngestionModuleMetadata Metadata => IInputIngestionPipelineModule.Meta("pipelines.input-ingestion.datapart", InputIngestionPipelineModuleKinds.DataPartsProcessor, priority: 0);

        public bool CanProcess(IInputItemContext inputItemContext)
        {
            return inputItemContext.Data.DataEnvelope.Parts.Count > 0;
        }

        public async Task<IResult<IInputIngestionPipelineRunResult>> Run(IInputIngestionPipelineRunContext context, CancellationToken ct)
        {
            IInputItemContext inputItemContext = context.InputItem;

            try
            {
                IOrderedEnumerable<IDataPartPipelineModule> orderedModules = modules.DataPartPipelineModules.OrderBy(c => c.Metadata.Kind);

                logger.LogDebug("Will running data part pipeline with {ModuleCount} modules in order :", orderedModules.Count());
                int index = 1;
                foreach (IDataPartPipelineModule module in orderedModules)
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
                IOrderedEnumerable<IGrouping<int, IDataPartPipelineModule>> groups = orderedModules
                    .GroupBy(m => (int)m.Metadata.Kind)
                    .OrderBy(g => g.Key);

                foreach (IDataPart part in context.InputItem.Data.DataEnvelope.Parts)
                {
                    foreach (IGrouping<int, IDataPartPipelineModule> group in groups)
                    {
                        logger.LogInformation("Running data part pipeline group Kind={Kind} with {Count} modules",
                            group.Key, group.Count());

                        await Task.WhenAll(group.OrderBy(x => x.Metadata.Priority).Select(async module =>
                        {
                            if (module.CanProcess(context.InputItem, part))
                            {
                                logger.LogInformation(
                                    "Running data part pipeline module: {ModuleName} (Kind: {ModuleKind}, Priority: {ModulePriority})",
                                    module.Metadata.Id,
                                    module.Metadata.Kind,
                                    module.Metadata.Priority);

                                IInputItemContextPatchBuilder modulePatcher = serviceProvider.GetRequiredService<IInputItemContextPatchBuilder>();

                                IInputItemContextPatch modulePatch = await module.Run(inputItemContext, modulePatcher.InitNew(), part, ct);
                                //inputItemContext = await inputItemContextPatcher.Patch(inputItemContext, modulePatch);

                                _ = context.Patch(b => b.Combine(modulePatch));
                            }
                            else
                            {
                                logger.LogInformation(
                                    "Skipping data part pipeline module: {ModuleName} (Kind: {ModuleKind}, Priority: {ModulePriority}) - Cannot process part with id {PartId}",
                                    module.Metadata.Id,
                                    module.Metadata.Kind,
                                    module.Metadata.Priority,
                                    part.PartId);
                            }
                        }));
                    }
                }
            }
            catch (OperationCanceledException) { throw; }
            catch (Exception ex)
            {
                return await context.Failure(ex);
            }

            return await context.Success();
        }
    }
}
