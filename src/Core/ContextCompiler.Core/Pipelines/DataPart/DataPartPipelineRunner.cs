using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.DataPart
{
    internal sealed class DataPartPipelineRunner(IModulesRegistry modules,
                                                 IDocumentContextPatcher documentContextPatcher,
                                                 IServiceProvider serviceProvider,
                                                 ILogger<DataPartPipelineRunner> logger) : IDocumentPipelineModule
    {

        public DocumentModuleMetadata Metadata => IDocumentPipelineModule.Meta("pipelines.document.datapart", DocumentPipelineModuleKinds.DataPartsProcessor, priority: 0);

        public bool CanProcess(IDocumentContext documentContext)
        {
            return documentContext.Data.DataEnvelope.Parts.Count > 0;
        }

        public async Task<IDocumentContextPatch> Run(IDocumentContext documentContext, IDocumentContextPatchBuilder patcher, CancellationToken ct)
        {
            try
            {
                IOrderedEnumerable<IDocumentPartPipelineModule> orderedModules = modules.DocumentPartPipelineModules.OrderBy(c => c.Metadata.Kind);

                logger.LogDebug("Will running document part pipeline with {ModuleCount} modules in order :", orderedModules.Count());
                int index = 1;
                foreach (IDocumentPartPipelineModule module in orderedModules)
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
                IOrderedEnumerable<IGrouping<int, IDocumentPartPipelineModule>> groups = orderedModules
                    .GroupBy(m => (int)m.Metadata.Kind)
                    .OrderBy(g => g.Key);

                foreach (IDataPart part in documentContext.Data.DataEnvelope.Parts)
                {
                    foreach (IGrouping<int, IDocumentPartPipelineModule> group in groups)
                    {
                        logger.LogInformation("Running document part pipeline group Kind={Kind} with {Count} modules",
                            group.Key, group.Count());

                        await Task.WhenAll(group.OrderBy(x => x.Metadata.Priority).Select(async module =>
                        {
                            if (module.CanProcess(documentContext, part))
                            {
                                logger.LogInformation(
                                    "Running document part pipeline module: {ModuleName} (Kind: {ModuleKind}, Priority: {ModulePriority})",
                                    module.Metadata.Id,
                                    module.Metadata.Kind,
                                    module.Metadata.Priority);

                                IDocumentContextPatchBuilder modulePatcher = serviceProvider.GetRequiredService<IDocumentContextPatchBuilder>();

                                IDocumentContextPatch modulePatch = await module.Run(documentContext, modulePatcher.InitNew(), part, ct);
                                documentContext = await documentContextPatcher.Patch(documentContext, modulePatch);

                                _ = patcher.Combine(modulePatch);
                            }
                            else
                            {
                                logger.LogInformation(
                                    "Skipping document part pipeline module: {ModuleName} (Kind: {ModuleKind}, Priority: {ModulePriority}) - Cannot process part with id {PartId}",
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
                _ = patcher.AddFinding(
                    FindingSeverity.Critical,
                    FindingAction.Block,
                    PassId: "pipeline.runner",
                    Message: $"Internal error: {ex.GetType().Name}"
                );
            }

            return patcher.Build();
        }
    }
}
