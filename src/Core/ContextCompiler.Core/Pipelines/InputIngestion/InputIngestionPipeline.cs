using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Abstractions.Pipelines.Events;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Sources;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.InputIngestion;

public sealed record InputItemCompileResult(
    string Path,
    IReadOnlyList<IFragment> Fragments,
    IReadOnlyList<GuardFinding> Findings
) : IInputItemCompileResult;

public sealed class InputIngestionPipeline(
    ILogger<InputIngestionPipeline> logger,
    IWorkingFolder workingFolder,
    IGuardian guardian,
    IReasoningIr reasoningIr,
    IFileSystem fs,
    IHasher hasher,
    IModulesRegistry modules,
    IFragmentBuilder fragmentBuilder,
    ITagsBuilder tagsBuilder,
    IConfigProvider cfgProvider,
    IInputItemContextBuilder inputItemContextBuilder,
    IInputItemContextPatchBuilder inputItemContextPatchBuilder,
    IInputItemContextPatcher inputItemContextPatcher,
    IInputIngestionPipelineRunContextBuilder runContextBuilder,
    ISourcesProvider sourcesProvider,
    IServiceProvider serviceProvider,
    IPipelineEventPublisher pipelineEventPublisher) : IGlobalPipelineModule, IPipeline
{

    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("pipelines.input-ingestion", GlobalPipelineModuleKinds.InputIngestion, priority: 10);

    public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        InputIngestionContext inputIngestionContext = new() { RootPath = workingFolder.Path };

        foreach (ISource s in sourcesProvider.GetAll())
        {
            Matcher matcher = new();
            matcher.AddExcludePatterns(["**/.git/**", "**/bin/**", "**/obj/**", "**/.ctxc/**"]);
            matcher.AddIncludePatterns(s.Includes);
            matcher.AddExcludePatterns(s.Excludes);

            PatternMatchingResult result = matcher.Execute(new DirectoryInfoWrapper(new DirectoryInfo(s.RootPath)));

            foreach (FilePatternMatch filePatternMatch in result.Files)
            {
                cancellationToken.ThrowIfCancellationRequested();

                IInputItemContext inputItemContext = inputItemContextBuilder.InitNew()
                    .WithInputRoot(s.RootPath)
                    .WithRelativePath(filePatternMatch.Path)
                    .WithFullPath(Path.Combine(s.RootPath, filePatternMatch.Path))
                    .FromSource(s)
                    .Build();


                try
                {
                    IOrderedEnumerable<IInputIngestionPipelineModule> orderedModules = modules.InputIngestionPipelineModules.OrderBy(c => c.Metadata.Kind);

                    logger.LogDebug("Will running Input Ingestion Pipeline with {ModuleCount} modules in order :", orderedModules.Count());
                    int index = 1;
                    foreach (IInputIngestionPipelineModule module in orderedModules)
                    {
                        logger.LogDebug("{Index}: {ModuleName} (Kind: {ModuleKind} ({ModuleKindValue}), Priority: {ModulePriority})",
                            index, module.Metadata.Id, module.Metadata.Kind, module.Metadata.Kind.ToString("D"), module.Metadata.Priority);
                        index++;
                    }

                    // Exécution par groupe de Kind, chaque groupe en parallèle,
                    // mais les groupes s'exécutent séquentiellement
                    IOrderedEnumerable<IGrouping<int, IInputIngestionPipelineModule>> groups = orderedModules
                        .GroupBy(m => (int)m.Metadata.Kind)
                        .OrderBy(g => g.Key);

                    foreach (IGrouping<int, IInputIngestionPipelineModule> group in groups)
                    {
                        logger.LogInformation("Running Input Ingestion Pipeline group Kind={Kind} with {Count} modules",
                            group.Key, group.Count());

                        await Task.WhenAll(group.OrderBy(x => x.Metadata.Priority).Select(async module =>
                        {
                            if (module.CanProcess(inputItemContext))
                            {
                                logger.LogInformation(
                                    "Running Input Ingestion Pipeline module: {ModuleName} (Kind: {ModuleKind}, Priority: {ModulePriority})",
                                    module.Metadata.Id,
                                    module.Metadata.Kind,
                                    module.Metadata.Priority);

                                IInputItemContextPatchBuilder modulePatcher = serviceProvider.GetRequiredService<IInputItemContextPatchBuilder>();

                                IInputIngestionPipelineRunContext innerRunContext = runContextBuilder
                                    .InitNew()
                                    .WithPipeline(this)
                                    .WithInputItemContext(inputItemContext)
                                    .WithPatchContext(modulePatcher.InitNew())
                                    .Build();

                                await pipelineEventPublisher.PublishPhaseAsync(this,
                                                               module.Metadata.Kind.ToString(),
                                                               module.Metadata.Id,
                                                               async () =>
                                                               {
                                                                   IResult<IInputIngestionPipelineRunResult> result = await module.Run(innerRunContext, cancellationToken);

                                                                   if (result is ISuccessResult<IInputIngestionPipelineRunResult> successResult)
                                                                   {
                                                                       inputItemContext = await inputItemContextPatcher.Patch(inputItemContext, successResult.Value.Patch);
                                                                   }

                                                               },
                                                               cancellationToken);
                            }
                            else
                            {
                                logger.LogInformation(
                                    "Skipping Input Ingestion Pipeline module (CanProcess returned false): {ModuleName} (Kind: {ModuleKind}, Priority: {ModulePriority})",
                                    module.Metadata.Id,
                                    module.Metadata.Kind,
                                    module.Metadata.Priority);
                            }
                        }));
                    }

                    //return new PipelineRunResult(true, 0, inputItemContext.Findings);
                }
                catch (OperationCanceledException) { throw; }
                catch (Exception ex)
                {
                    _ = inputItemContextPatchBuilder.AddFinding(
                        FindingSeverity.Critical,
                        FindingAction.Block,
                        PassId: "pipeline.runner",
                        Message: $"Internal error: {ex.GetType().Name}"
                    );

                    //return new PipelineRunResult(false, ExitCode: 1, inputItemContext.Findings);
                }
                IInputItemContextPatch patch = inputItemContextPatchBuilder.Build();
                inputItemContext = await inputItemContextPatcher.Patch(inputItemContext, patch);

                inputIngestionContext.AddInputItem(inputItemContext);
            }
        }

        guardian.Load(inputIngestionContext);

        IReadOnlyList<IPipelineFinding> findings = guardian.Findings;
        if (findings.Any(f => f.Action == FindingAction.Block && f.Severity == FindingSeverity.Critical))
        {
            throw new PipelineAbortedException("Pipeline aborted due to critical findings in input ingestion context.");
        }

        foreach (IInputItemContext r in inputIngestionContext.InputItems)
        {
            foreach (IFragment f in r.Data.Fragments)
            {
                reasoningIr.Add(f);
            }
        }

        return await context.Success();
    }

    //private static IReadOnlyList<DataPart>? TryGetCompositeParts(DataEnvelope env)
    //{
    //    if (env.Shape != DataShape.Composite) return null;
    //    if (env.Payload is CompositeDataEnvelope c) return c.Parts;
    //    return null;
    //}

    //private static string CombineLocator(string prefix, string? locator)
    //{
    //    if (string.IsNullOrEmpty(locator)) return prefix;
    //    if (string.IsNullOrEmpty(prefix)) return locator ?? string.Empty;
    //    return prefix + "/" + locator;
    //}

    //private async Task<IReadOnlyList<GuardFinding>> RunGuardsAsync(GuardStage stage, GuardContext ctx, CancellationToken ct)
    //{
    //    var guards = plugins.Guards.Where(g => g.Stage == stage).OrderBy(g => g.Metadata.Priority).ToList();
    //    var findings = new List<GuardFinding>();
    //    foreach (var g in guards)
    //    {
    //        var f = await g.EvaluateAsync(ctx, ct);
    //        if (f.Count > 0) findings.AddRange(f);
    //    }
    //    return findings;
    //}
}
