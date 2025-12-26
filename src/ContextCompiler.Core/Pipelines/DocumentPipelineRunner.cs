using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Core.ReasoningIR;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines;

public sealed record DocumentCompileResult(
    string Path,
    IReadOnlyList<Fragment> Fragments,
    IReadOnlyList<GuardFinding> Findings
);

public sealed class DocumentPipelineRunner(
    ILogger logger,
    IFileSystem fs,
    IHasher hasher,
    IPluginRegistry plugins)
{
    public async Task<IReadOnlyList<DocumentCompileResult>> RunAsync(string rootPath, CancellationToken ct)
    {
        var results = new List<DocumentCompileResult>();

        var allFiles = fs.EnumerateFiles(rootPath)
            .Where(p => !p.Contains(Path.DirectorySeparatorChar + ".git" + Path.DirectorySeparatorChar))
            .Where(p => !p.Contains(Path.DirectorySeparatorChar + ".ctxboost" + Path.DirectorySeparatorChar))
            .Where(p => !p.Contains(Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar))
            .Where(p => !p.Contains(Path.DirectorySeparatorChar + "obj" + Path.DirectorySeparatorChar))
            .ToList();

        var discoveryFindings = await RunGuardsAsync(GuardStage.Discovery, new GuardContext(rootPath), ct);
        if (discoveryFindings.Count > 0)
            results.Add(new DocumentCompileResult("__discovery__", Array.Empty<Fragment>(), discoveryFindings));

        foreach (var file in allFiles)
        {
            ct.ThrowIfCancellationRequested();

            var readFindings = await RunGuardsAsync(GuardStage.Read, new GuardContext(rootPath, file), ct);
            if (readFindings.Any(f => f.Action is GuardActionKind.Skip or GuardActionKind.Block))
            {
                results.Add(new DocumentCompileResult(file, Array.Empty<Fragment>(), readFindings));
                continue;
            }

            var reader = plugins.FileReaders.FirstOrDefault(r => r.CanRead(file));
            if (reader is null) continue;

            var doc = await reader.ReadAsync(file, ct);

            var dataReader = plugins.DataReaders.FirstOrDefault(r => r.CanRead(doc));
            if (dataReader is null)
            {
                results.Add(new DocumentCompileResult(file, Array.Empty<Fragment>(), readFindings));
                continue;
            }

            var envelope = await dataReader.ReadAsync(doc, ct);

            foreach (var mod in plugins.EngineeringModules.OrderBy(m => m.Metadata.Priority))
                envelope = await mod.ApplyAsync(envelope, ct);

            var fragFindings = await RunGuardsAsync(GuardStage.Fragment, new GuardContext(rootPath, file, doc.Text, doc, envelope), ct);

            if (fragFindings.Any(f => f.Action is GuardActionKind.Block))
            {
                results.Add(new DocumentCompileResult(file, Array.Empty<Fragment>(), readFindings.Concat(fragFindings).ToList()));
                continue;
            }

            var transcoder = plugins.Transcoders.FirstOrDefault(t => t.CanTranscode(envelope));
            if (transcoder is null)
            {
                results.Add(new DocumentCompileResult(file, Array.Empty<Fragment>(), readFindings.Concat(fragFindings).ToList()));
                continue;
            }

            var transcoded = await transcoder.TranscodeAsync(envelope, new SourceRef(file), ct);
            var fragments = transcoded.Select(tf =>
            {
                var ek = new EvidenceKey("E-" + hasher.Sha256Hex(file + "|" + tf.Locator)[..12]);
                var er = new EvidenceRevision("R-" + hasher.Sha256Hex(file + "|" + tf.Locator + "|" + tf.Content)[..12]);
                return new Fragment(ek, er, tf.Content, new SourceRef(file, tf.Locator), tf.Tags);
            }).ToList();

            results.Add(new DocumentCompileResult(file, fragments, readFindings.Concat(fragFindings).ToList()));
        }

        return results;
    }

    private async Task<IReadOnlyList<GuardFinding>> RunGuardsAsync(GuardStage stage, GuardContext ctx, CancellationToken ct)
    {
        var guards = plugins.Guards.Where(g => g.Stage == stage).OrderBy(g => g.Metadata.Priority).ToList();
        var findings = new List<GuardFinding>();
        foreach (var g in guards)
        {
            var f = await g.EvaluateAsync(ctx, ct);
            if (f.Count > 0) findings.AddRange(f);
        }
        return findings;
    }
}
