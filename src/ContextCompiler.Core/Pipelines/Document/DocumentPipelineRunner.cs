using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Tags;

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
    IPluginRegistry plugins,
    IFragmentBuilder fragmentBuilder,
    ITagsBuilder tagsBuilder,
    ICtxcConfigProvider cfgProvider,
    IEnumerable<IDocumentPass> passes,
    IServiceProvider serviceProvider) : IDocumentPipelineRunner
{
    public async ValueTask RunAsync(IDocumentsContext documentsContext, CancellationToken ct)
    {
        passes = passes
            .OrderBy(p => (int)p.Stage)
            .ThenBy(p => p.Priority)
            .ThenBy(p => p.Id, StringComparer.Ordinal)
            .ToArray();

        logger.LogInformation("Starting documents pipeline run in root path: {RootPath} ({Count} passes)", documentsContext.RootPath, passes.Count());

        logger.LogDebug("Document pipeline passes order: {Passes}", Environment.NewLine + string.Join(Environment.NewLine, passes));

        var results = new List<IDocumentCompileResult>();

        //var allFiles = fs.EnumerateFiles(rootPath)
        //    .Where(p => !p.Contains(Path.DirectorySeparatorChar + ".git" + Path.DirectorySeparatorChar))
        //    .Where(p => !p.Contains(Path.DirectorySeparatorChar + ".ctxboost" + Path.DirectorySeparatorChar))
        //    .Where(p => !p.Contains(Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar))
        //    .Where(p => !p.Contains(Path.DirectorySeparatorChar + "obj" + Path.DirectorySeparatorChar))
        //    .Where(p => !p.Contains(Path.DirectorySeparatorChar + ".ctxc" + Path.DirectorySeparatorChar))
        //    .ToList();

        Matcher matcher = new();
        matcher.AddExcludePatterns(["**/.git/**", "**/bin/**", "**/obj/**", "**/.ctxc/**"]);
        foreach (var s in cfgProvider.Current.Files.Select(x => x.Includes))
        {
            matcher.AddIncludePatterns(s);
            logger.LogInformation("Including file pattern: {Pattern}", string.Join(", ", s));
        }

        foreach (var s in cfgProvider.Current.Files.Select(x => x.Excludes))
        {
            matcher.AddExcludePatterns(s);
            logger.LogInformation("Excluding file pattern: {Pattern}", string.Join(", ", s));
        }


        PatternMatchingResult result = matcher.Execute(new DirectoryInfoWrapper(new DirectoryInfo(documentsContext.RootPath)));


        //var discoveryFindings = await RunGuardsAsync(GuardStage.Discovery, new GuardContext(rootPath), ct);
        //if (discoveryFindings.Count > 0)
        //    results.Add(new DocumentCompileResult("__discovery__", Array.Empty<Fragment>(), discoveryFindings));

        foreach (var filePatternMatch in result.Files)
        {
            ct.ThrowIfCancellationRequested();

            DocumentContext docContext = new DocumentContext(tagsBuilder, serviceProvider)
            {
                InputRoot = documentsContext.RootPath,
                RelativePath = filePatternMatch.Path,
                FullPath = Path.Combine(documentsContext.RootPath, filePatternMatch.Path)
            };
            documentsContext.AddDocument(docContext);

            try
            {
                foreach (var pass in passes)
                {
                    ct.ThrowIfCancellationRequested();
                    logger.LogDebug("Executing document pass '{PassId}' on document '{DocumentPath}'", pass.Id, docContext.RelativePath);

                    await pass.ExecuteAsync(docContext, ct);

                    // hard stop rule
                    var blocked = docContext.Findings.Any(f => f.Severity == FindingSeverity.Critical && f.Action == FindingAction.Block);
                    if (blocked)
                        break;
                }

                //return new PipelineRunResult(true, 0, docContext.Findings);
            }
            catch (OperationCanceledException) { throw; }
            catch (Exception ex)
            {
                docContext.AddFinding(
                    FindingSeverity.Critical,
                    FindingAction.Block,
                    PassId: "pipeline.runner",
                    Message: $"Internal error: {ex.GetType().Name}"
                );

                //return new PipelineRunResult(false, ExitCode: 1, docContext.Findings);
            }

            //var readFindings = await RunGuardsAsync(GuardStage.Read, new GuardContext(rootPath, filePath), ct);
            //if (readFindings.Any(f => f.Action is GuardActionKind.Skip or GuardActionKind.Block))
            //{
            //    results.Add(new DocumentCompileResult(filePath, Array.Empty<Fragment>(), readFindings));
            //    continue;
            //}

            //var reader = plugins.FileReaders.FirstOrDefault(r => r.CanRead(filePath));
            //if (reader is null) continue;

            //var doc = await reader.ReadAsync(filePath, ct);

            //var dataReader = plugins.DataReaders.FirstOrDefault(r => r.CanRead(doc));
            //if (dataReader is null)
            //{
            //    results.Add(new DocumentCompileResult(filePath, Array.Empty<Fragment>(), readFindings));
            //    continue;
            //}

            //var envelope = await dataReader.ReadAsync(doc, ct);

            //var compositeParts = TryGetCompositeParts(envelope);
            //if (compositeParts is not null)
            //{
            //    foreach (var part in compositeParts)
            //    {
            //        var partEnv = part.Envelope;
            //        foreach (var mod in plugins.EngineeringModules.OrderBy(m => m.Metadata.Priority))
            //            partEnv = await mod.ApplyAsync(partEnv, ct);

            //        var fragFindings = await RunGuardsAsync(GuardStage.Fragment, new GuardContext(rootPath, filePath, doc.Text, doc, partEnv), ct);
            //        if (fragFindings.Any(f => f.Action is GuardActionKind.Block))
            //        {
            //            results.Add(new DocumentCompileResult(filePath, Array.Empty<Fragment>(), readFindings.Concat(fragFindings).ToList()));
            //            continue;
            //        }

            //        var transcoder = plugins.Transcoders.FirstOrDefault(t => t.CanTranscode(partEnv));
            //        if (transcoder is null)
            //        {
            //            results.Add(new DocumentCompileResult(filePath, Array.Empty<Fragment>(), readFindings.Concat(fragFindings).ToList()));
            //            continue;
            //        }

            //        var transcoded = await transcoder.TranscodeAsync(partEnv, part.Source, ct);
            //        var fragments = transcoded.Select(tf =>
            //        {
            //            var locator = CombineLocator(part.Source.Locator ?? string.Empty, tf.Locator);
            //            IList<ITag> fragmentTags = tf.Tags is null ? new List<ITag>() : new List<ITag>(tf.Tags);
            //            fragmentTags.Add(new Tag("extractId", part.PartId));
            //            fragmentTags = tagBuilder.AddRange(fragmentTags, cfgFilesMatchTags);
            //            if (!string.IsNullOrWhiteSpace(part.Label)) fragmentTags.Add(new Tag("extractLabel", part.Label!));

            //            return fragmentBuilder.InitNew().WithTranscodedFragment(tf).WithFilePath(filePath).WithLocator(locator).WithTags(fragmentTags).Build();
            //        }).ToList();

            //        results.Add(new DocumentCompileResult(filePath, fragments, readFindings.Concat(fragFindings).ToList()));
            //    }
            //    continue; // handled composite
            //}

            //foreach (var mod in plugins.EngineeringModules.OrderBy(m => m.Metadata.Priority))
            //    envelope = await mod.ApplyAsync(envelope, ct);

            //var fragFindings2 = await RunGuardsAsync(GuardStage.Fragment, new GuardContext(rootPath, filePath, doc.Text, doc, envelope), ct);

            //if (fragFindings2.Any(f => f.Action is GuardActionKind.Block))
            //{
            //    results.Add(new DocumentCompileResult(filePath, Array.Empty<Fragment>(), readFindings.Concat(fragFindings2).ToList()));
            //    continue;
            //}

            //var transcoder2 = plugins.Transcoders.FirstOrDefault(t => t.CanTranscode(envelope));
            //if (transcoder2 is null)
            //{
            //    results.Add(new DocumentCompileResult(filePath, Array.Empty<Fragment>(), readFindings.Concat(fragFindings2).ToList()));
            //    continue;
            //}

            //var transcoded2 = await transcoder2.TranscodeAsync(envelope, new SourceRef(filePath), ct);
            //var fragments2 = transcoded2.Select(tf =>
            //{
            //    IList<ITag> fragmentTags = tf.Tags is null ? new List<ITag>() : new List<ITag>(tf.Tags);
            //    fragmentTags = tagBuilder.AddRange(fragmentTags, cfgFilesMatchTags);
            //    return fragmentBuilder.InitNew().WithTranscodedFragment(tf).WithFilePath(filePath).WithLocator(tf.Locator).WithTags(fragmentTags).Build();
            //}).ToList();

            //results.Add(new DocumentCompileResult(filePath, fragments2, readFindings.Concat(fragFindings2).ToList()));
        }

        //return results;
        //return new PipelineRunResult(true, 0, Array.Empty<GuardFinding>());
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
