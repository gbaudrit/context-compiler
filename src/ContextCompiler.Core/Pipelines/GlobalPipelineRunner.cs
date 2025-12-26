using System.Text.Json;
using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Core.ReasoningIR;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines;

public sealed record GlobalCompileOutputs(
    IReadOnlyDictionary<string, string> Artifacts,
    GraphModel Graph,
    IReadOnlyList<GuardFinding> Findings
);

public sealed class GlobalPipelineRunner(
    ILogger logger,
    IFileSystem fs,
    IHasher hasher,
    IPluginRegistry plugins)
{
    public async Task<GlobalCompileOutputs> RunAsync(
        string rootPath,
        string outputPath,
        ReasoningIr ir,
        IReadOnlyList<GuardFinding> findings,
        CompileOptions options,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        fs.EnsureDirectory(outputPath);

        var views = new List<ViewResult>();
        foreach (var v in plugins.Views.OrderBy(v => v.Metadata.Priority))
            views.Add(await v.BuildAsync(new ViewContext(rootPath, ir), ct));

        if (views.Count == 0)
        {
            views.Add(new ViewResult("default", "Default View",
                string.Join("\n\n", ir.Fragments.Select(f => $"### {f.Key.Value}\n{f.Content}\n"))));
        }

        var compiledViews = string.Join("\n\n---\n\n", views.Select(v => $"# {v.Title}\n\n{v.RenderedMarkdown}"));

        var template = plugins.Templates.OrderBy(t => t.Metadata.Priority).FirstOrDefault();
        var finalPrompt = template is null ? compiledViews : template.Apply(compiledViews);

        if (finalPrompt.Length > options.MaxCharacters)
            finalPrompt = finalPrompt[..options.MaxCharacters] + "\n\n<!-- truncated by Context Compiler -->\n";

        // Graph
        var graph = new GraphModel();
        foreach (var frag in ir.Fragments)
        {
            graph.Nodes.Add(new GraphNode(frag.Key.Value, "Evidence", frag.Key.Value, new Dictionary<string,string>
            {
                ["source"] = frag.Source.Path,
                ["locator"] = frag.Source.Locator ?? ""
            }));
            var srcId = "S-" + hasher.Sha256Hex(frag.Source.Path)[..10];
            if (!graph.Nodes.Any(n => n.Id == srcId))
                graph.Nodes.Add(new GraphNode(srcId, "Source", Path.GetFileName(frag.Source.Path), new Dictionary<string,string>{{"path",frag.Source.Path}}));
            graph.Edges.Add(new GraphEdge(frag.Key.Value, srcId, "DerivedFrom"));
        }

        var artifacts = new Dictionary<string, string>();

        void WriteArtifact(string name, string content)
        {
            var p = Path.Combine(outputPath, name);
            fs.WriteAllText(p, content);
            artifacts[name] = p;
        }

        WriteArtifact("prompt.context.md", finalPrompt);

        var evidenceIndex = ir.Fragments.Select(f => new
        {
            evidenceKey = f.Key.Value,
            evidenceRevision = f.Revision.Value,
            source = new { path = f.Source.Path, locator = f.Source.Locator },
            tags = f.Tags
        }).ToList();
        WriteArtifact("evidence.index.json", JsonSerializer.Serialize(evidenceIndex, new JsonSerializerOptions { WriteIndented = true }));

        WriteArtifact("reasoning.graph.json", JsonSerializer.Serialize(graph, new JsonSerializerOptions { WriteIndented = true }));

        var secMd = "# Security Report\n\n" + (findings.Count == 0 ? "No findings." :
            string.Join("\n", findings.Select(f => $"- **{f.Severity}** `{f.GuardId}` ({f.Action}): {f.Message} — `{f.Source.Path}`")));
        WriteArtifact("security.report.md", secMd);

        var health = new
        {
            fragments = ir.Fragments.Count,
            findings = findings.Count,
            views = views.Count,
            score = Math.Max(0, 100 - findings.Count * 5)
        };
        WriteArtifact("context.health.json", JsonSerializer.Serialize(health, new JsonSerializerOptions{WriteIndented=true}));

        foreach (var exp in plugins.GraphExporters.OrderBy(e => e.Metadata.Priority))
        {
            var content = exp.Export(graph);
            WriteArtifact("reasoning.graph" + exp.FileExtension, content);
        }

        foreach (var v in views)
            WriteArtifact($"view.{v.ViewId}.md", v.RenderedMarkdown);

        // Preflight
        var preflight = new List<GuardFinding>();
        foreach (var g in plugins.Guards.Where(g => g.Stage == GuardStage.Preflight).OrderBy(g => g.Metadata.Priority))
            preflight.AddRange(await g.EvaluateAsync(new GuardContext(rootPath, Text: finalPrompt), ct));

        if (preflight.Count > 0)
        {
            findings = findings.Concat(preflight).ToList();
            var preMd = "# Preflight Findings\n\n" + string.Join("\n", preflight.Select(f => $"- **{f.Severity}** `{f.GuardId}` ({f.Action}): {f.Message}"));
            WriteArtifact("preflight.report.md", preMd);
        }

        return new GlobalCompileOutputs(artifacts, graph, findings);
    }
}
