using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Pipelines.Events;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Sources;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.BuiltIn;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Document;

public sealed record DocumentCompileResult(
    string Path,
    IReadOnlyList<IFragment> Fragments,
    IReadOnlyList<GuardFinding> Findings
) : IDocumentCompileResult;

public sealed class DocumentPipeline(
    ILogger<DocumentPipeline> logger,
    IWorkingFolder workingFolder,
    IGuardian guardian,
    IReasoningIr reasoningIr,
    IFileSystem fs,
    IHasher hasher,
    IModulesRegistry modules,
    IFragmentBuilder fragmentBuilder,
    ITagsBuilder tagsBuilder,
    IConfigProvider cfgProvider,
    IDocumentContextBuilder documentContextBuilder,
    IDocumentContextPatchBuilder documentContextPatchBuilder,
    IDocumentContextPatcher documentContextPatcher,
    IDocumentPipelineRunContextBuilder runContextBuilder,
    ISourcesProvider sourcesProvider,
    IServiceProvider serviceProvider,
    IPipelineEventPublisher pipelineEventPublisher) : IGlobalPipelineModule, IPipeline
{

    public ModuleMetadata Metadata => BuiltInMetadata.Meta("pipelines.documents", GlobalPipelineModuleKinds.InputIngestion, priority: 10);

    public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        DocumentsContext documentsContext = new() { RootPath = workingFolder.Path };

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

                IDocumentContext docContext = documentContextBuilder.InitNew()
                    .WithInputRoot(s.RootPath)
                    .WithRelativePath(filePatternMatch.Path)
                    .WithFullPath(Path.Combine(s.RootPath, filePatternMatch.Path))
                    .FromSource(s)
                    .Build();


                try
                {
                    IOrderedEnumerable<IDocumentPipelineModule> orderedModules = modules.DocumentPipelineModules.OrderBy(c => c.Metadata.Kind);

                    logger.LogDebug("Will running document pipeline with {ModuleCount} modules in order :", orderedModules.Count());
                    int index = 1;
                    foreach (IDocumentPipelineModule module in orderedModules)
                    {
                        logger.LogDebug("{Index}: {ModuleName} (Kind: {ModuleKind} ({ModuleKindValue}), Priority: {ModulePriority})",
                            index, module.Metadata.Id, module.Metadata.Kind, module.Metadata.Kind.ToString("D"), module.Metadata.Priority);
                        index++;
                    }

                    // Exécution par groupe de Kind, chaque groupe en parallèle,
                    // mais les groupes s'exécutent séquentiellement
                    IOrderedEnumerable<IGrouping<int, IDocumentPipelineModule>> groups = orderedModules
                        .GroupBy(m => (int)m.Metadata.Kind)
                        .OrderBy(g => g.Key);

                    foreach (IGrouping<int, IDocumentPipelineModule> group in groups)
                    {
                        logger.LogInformation("Running document pipeline group Kind={Kind} with {Count} modules",
                            group.Key, group.Count());

                        await Task.WhenAll(group.OrderBy(x => x.Metadata.Priority).Select(async module =>
                        {
                            if (module.CanProcess(docContext))
                            {
                                logger.LogInformation(
                                    "Running document pipeline module: {ModuleName} (Kind: {ModuleKind}, Priority: {ModulePriority})",
                                    module.Metadata.Id,
                                    module.Metadata.Kind,
                                    module.Metadata.Priority);

                                IDocumentContextPatchBuilder modulePatcher = serviceProvider.GetRequiredService<IDocumentContextPatchBuilder>();

                                IDocumentPipelineRunContext innerRunContext = runContextBuilder
                                    .InitNew()
                                    .WithPipeline(this)
                                    .WithDocumentContext(docContext)
                                    .WithPatchContext(modulePatcher.InitNew())
                                    .Build();

                                await pipelineEventPublisher.PublishPhaseAsync(this,
                                                               module.Metadata.Kind.ToString(),
                                                               module.Metadata.Id,
                                                               async () =>
                                                               {
                                                                   IResult<IDocumentPipelineRunResult> result = await module.Run(innerRunContext, cancellationToken);

                                                                   if (result is ISuccessResult<IDocumentPipelineRunResult> successResult)
                                                                   {
                                                                       docContext = await documentContextPatcher.Patch(docContext, successResult.Value.Patch);
                                                                   }

                                                               },
                                                               cancellationToken);
                            }
                            else
                            {
                                logger.LogInformation(
                                    "Skipping document pipeline module (CanProcess returned false): {ModuleName} (Kind: {ModuleKind}, Priority: {ModulePriority})",
                                    module.Metadata.Id,
                                    module.Metadata.Kind,
                                    module.Metadata.Priority);
                            }
                        }));
                    }

                    //return new PipelineRunResult(true, 0, docContext.Findings);
                }
                catch (OperationCanceledException) { throw; }
                catch (Exception ex)
                {
                    _ = documentContextPatchBuilder.AddFinding(
                        FindingSeverity.Critical,
                        FindingAction.Block,
                        PassId: "pipeline.runner",
                        Message: $"Internal error: {ex.GetType().Name}"
                    );

                    //return new PipelineRunResult(false, ExitCode: 1, docContext.Findings);
                }
                IDocumentContextPatch patch = documentContextPatchBuilder.Build();
                docContext = await documentContextPatcher.Patch(docContext, patch);

                documentsContext.AddDocument(docContext);
            }
        }

        guardian.Load(documentsContext);

        IReadOnlyList<IPipelineFinding> findings = guardian.Findings;
        if (findings.Any(f => f.Action == FindingAction.Block && f.Severity == FindingSeverity.Critical))
        {
            throw new PipelineAbortedException("Pipeline aborted due to critical findings in documents context.");
        }

        foreach (IDocumentContext r in documentsContext.Documents)
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
