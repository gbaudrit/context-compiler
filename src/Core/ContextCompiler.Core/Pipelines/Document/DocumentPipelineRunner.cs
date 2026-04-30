using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Sources;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Modules.Abstractions;

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

public sealed class DocumentPipelineRunner(
    ILogger<DocumentPipelineRunner> logger,
    IFileSystem fs,
    IHasher hasher,
    IModulesRegistry modules,
    IFragmentBuilder fragmentBuilder,
    ITagsBuilder tagsBuilder,
    IConfigProvider cfgProvider,
    IEnumerable<IDocumentPass> passes,
    IDocumentContextBuilder documentContextBuilder,
    IDocumentContextPatchBuilder documentContextPatchBuilder,
    IDocumentContextPatcher documentContextPatcher,
    ISourcesProvider sourcesProvider,
    IServiceProvider serviceProvider) : IDocumentPipelineRunner
{
    public async ValueTask RunAsync(IDocumentsContext documentsContext, CancellationToken ct)
    {
        passes = [.. passes
            .OrderBy(p => (int)p.Metadata.Stage)
            .ThenBy(p => p.Metadata.Priority)
            .ThenBy(p => p.Metadata.Id, StringComparer.Ordinal)];

        logger.LogInformation("Starting documents pipeline run in root path: {RootPath} ({Count} passes)", documentsContext.RootPath, passes.Count());

        logger.LogDebug("Document pipeline passes order: {Passes}", Environment.NewLine + string.Join(Environment.NewLine, passes.Select(p => $"{p.Metadata.Id} (Kind: {p.Metadata.Kind}, Stage: {p.Metadata.Stage}, Priority: {p.Metadata.Priority})")));

        List<IDocumentCompileResult> results = [];

        //var allFiles = fs.EnumerateFiles(rootPath)
        //    .Where(p => !p.Contains(Path.DirectorySeparatorChar + ".git" + Path.DirectorySeparatorChar))
        //    .Where(p => !p.Contains(Path.DirectorySeparatorChar + ".ctxboost" + Path.DirectorySeparatorChar))
        //    .Where(p => !p.Contains(Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar))
        //    .Where(p => !p.Contains(Path.DirectorySeparatorChar + "obj" + Path.DirectorySeparatorChar))
        //    .Where(p => !p.Contains(Path.DirectorySeparatorChar + ".ctxc" + Path.DirectorySeparatorChar))
        //    .ToList();

        foreach (ISource s in sourcesProvider.GetAll())
        {
            Matcher matcher = new();
            matcher.AddExcludePatterns(["**/.git/**", "**/bin/**", "**/obj/**", "**/.ctxc/**"]);
            matcher.AddIncludePatterns(s.Includes);
            matcher.AddExcludePatterns(s.Excludes);

            PatternMatchingResult result = matcher.Execute(new DirectoryInfoWrapper(new DirectoryInfo(s.RootPath)));

            foreach (FilePatternMatch filePatternMatch in result.Files)
            {
                ct.ThrowIfCancellationRequested();

                IDocumentContext docContext = documentContextBuilder.InitNew()
                    .WithInputRoot(s.RootPath)
                    .WithRelativePath(filePatternMatch.Path)
                    .WithFullPath(Path.Combine(s.RootPath, filePatternMatch.Path))
                    .FromSource(s)
                    .Build();


                try
                {
                    //foreach (IDocumentPass pass in passes)
                    //{
                    //    ct.ThrowIfCancellationRequested();
                    //    logger.LogDebug("Executing document pass '{PassId}' on document '{DocumentPath}'", pass.Id, docContext.RelativePath);

                    //    await pass.ExecuteAsync(docContext, ct);

                    //    // hard stop rule
                    //    bool blocked = docContext.Findings.Any(f => f.Severity == FindingSeverity.Critical && f.Action == FindingAction.Block);
                    //    if (blocked)
                    //    {
                    //        break;
                    //    }
                    //}

                    IOrderedEnumerable<IDocumentPipelineModule> orderedModules = modules.DocumentPipelineModules.OrderBy(c => c.Metadata.Kind);

                    logger.LogDebug("Will running document pipeline with {ModuleCount} modules in order :", orderedModules.Count());
                    int index = 1;
                    foreach (IDocumentPipelineModule module in orderedModules)
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

                                IDocumentContextPatch patch = await module.Run(docContext, modulePatcher.InitNew(), ct);
                                docContext = await documentContextPatcher.Patch(docContext, patch);
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
