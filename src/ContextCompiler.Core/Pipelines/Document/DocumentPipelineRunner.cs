using System.Text.Json;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Modules.Abstractions;

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
    ICtxcConfigProvider cfgProvider,
    IEnumerable<IDocumentPass> passes,
    IDocumentContextBuilder documentContextBuilder,
    IServiceProvider serviceProvider) : IDocumentPipelineRunner
{
    public async ValueTask RunAsync(IDocumentsContext documentsContext, CancellationToken ct)
    {
        passes = [.. passes
            .OrderBy(p => (int)p.Stage)
            .ThenBy(p => p.Priority)
            .ThenBy(p => p.Id, StringComparer.Ordinal)];

        logger.LogInformation("Starting documents pipeline run in root path: {RootPath} ({Count} passes)", documentsContext.RootPath, passes.Count());

        logger.LogDebug("Document pipeline passes order: {Passes}", Environment.NewLine + string.Join(Environment.NewLine, passes));

        List<IDocumentCompileResult> results = [];

        //var allFiles = fs.EnumerateFiles(rootPath)
        //    .Where(p => !p.Contains(Path.DirectorySeparatorChar + ".git" + Path.DirectorySeparatorChar))
        //    .Where(p => !p.Contains(Path.DirectorySeparatorChar + ".ctxboost" + Path.DirectorySeparatorChar))
        //    .Where(p => !p.Contains(Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar))
        //    .Where(p => !p.Contains(Path.DirectorySeparatorChar + "obj" + Path.DirectorySeparatorChar))
        //    .Where(p => !p.Contains(Path.DirectorySeparatorChar + ".ctxc" + Path.DirectorySeparatorChar))
        //    .ToList();

        foreach (IFileConfig s in cfgProvider.Current.Files)
        {
            Matcher matcher = new();
            matcher.AddExcludePatterns(["**/.git/**", "**/bin/**", "**/obj/**", "**/.ctxc/**"]);
            matcher.AddIncludePatterns(s.Includes);
            matcher.AddExcludePatterns(s.Excludes);

            PatternMatchingResult result = matcher.Execute(new DirectoryInfoWrapper(new DirectoryInfo(documentsContext.RootPath)));

            foreach (FilePatternMatch filePatternMatch in result.Files)
            {
                ct.ThrowIfCancellationRequested();

                IDocumentContext docContext = documentContextBuilder.InitNew()
                    .WithInputRoot(documentsContext.RootPath)
                    .WithRelativePath(filePatternMatch.Path)
                    .WithFullPath(Path.Combine(documentsContext.RootPath, filePatternMatch.Path))
                    .WithExtractOptions(s.Options ?? JsonElement.Parse("{}"))
                    .Build();
                documentsContext.AddDocument(docContext);

                try
                {
                    foreach (IDocumentPass pass in passes)
                    {
                        ct.ThrowIfCancellationRequested();
                        logger.LogDebug("Executing document pass '{PassId}' on document '{DocumentPath}'", pass.Id, docContext.RelativePath);

                        await pass.ExecuteAsync(docContext, ct);

                        // hard stop rule
                        bool blocked = docContext.Findings.Any(f => f.Severity == FindingSeverity.Critical && f.Action == FindingAction.Block);
                        if (blocked)
                        {
                            break;
                        }
                    }

                    //return new PipelineRunResult(true, 0, docContext.Findings);
                }
                catch (OperationCanceledException) { throw; }
                catch (Exception ex)
                {
                    _ = docContext.AddFinding(
                        FindingSeverity.Critical,
                        FindingAction.Block,
                        PassId: "pipeline.runner",
                        Message: $"Internal error: {ex.GetType().Name}"
                    );

                    //return new PipelineRunResult(false, ExitCode: 1, docContext.Findings);
                }
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
