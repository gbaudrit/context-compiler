using System.Globalization;
using System.Text;
using System.Text.Json;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Core.ReasoningIR;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines;

public sealed record GlobalCompileOutputs(
    IReadOnlyDictionary<string, string> Artifacts,
    GraphModel Graph,
    IReadOnlyList<IPipelineFinding> Findings
);

public sealed class GlobalPipelineRunner(
    ILogger<GlobalPipelineRunner> logger,
    IDocumentContextBuilder docCtxBuilder,
    IFileSystem fs,
    IHasher hasher,
    IPluginRegistry plugins,
    ICtxcConfigProvider cfgProvider,
    IGuardian guardian) : IGlobalPipelineRunner
{
    private static readonly JsonSerializerOptions s_jsonIndentedOptions = new() { WriteIndented = true };

    public async ValueTask RunAsync(
        string rootPath,
        string outputPath,
        IReasoningIr ir,
        IReadOnlyList<IPipelineFinding> findings,
        CompileOptions options,
        IPlugins<IOutputPlugin> outputPlugins,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        fs.EnsureDirectory(outputPath);

        var cfg = cfgProvider.Current;

        var views = new List<ViewResult>();
        foreach (var v in plugins.Views.OrderBy(v => v.Metadata.Priority))
            views.AddRange(await v.BuildAsync(new ViewContext(cfg.Views, rootPath, ir), ct));

        if (views.Count == 0)
        {
            views.Add(new ViewResult("default", "Default View",
                string.Join("\n\n", ir.Fragments.Select(f => $"### {f.Evidence.EvidenceKey}\n{f.Content}\n")), "", "", ""));
        }
        Prompt prompt = new();

        //string.Join("\n\n---\n\n", views.Select(v => $"# {v.Title}\n\n{v.Rendered}"));
        prompt.Views = views;


        // Global Context rendering (before personas)
        if (cfg.Context?.Enabled == true)
        {
            prompt.Global = RenderGlobalContext(cfg.Context);
        }

        // Personas (existing integration)
        string personaFraming = string.Empty;
        var personasMeta = new List<object>();
        if (cfg.Personas is not null && cfg.Personas.Active.Count > 0)
        {
            personaFraming = "# Persona (roles)";
            foreach (var id in cfg.Personas.Active)
            {
                var plugin = plugins.Personas.FirstOrDefault(p => string.Equals(p.PersonaId, id, StringComparison.Ordinal));
                if (plugin is null)
                {
                    logger.LogWarning("Persona not found: {Id}", id);
                    continue;
                }
                IReadOnlyDictionary<string, object>? inputs = null;
                if (cfg.Personas.Params is not null && cfg.Personas.Params.TryGetValue(id, out var pval) && pval is not null)
                {
                    if (pval is JsonElement je && je.ValueKind == JsonValueKind.Object)
                    {
                        var dict = new Dictionary<string, object>();
                        foreach (var prop in je.EnumerateObject())
                            dict[prop.Name] = prop.Value.ToString();
                        inputs = dict;
                    }
                }
                var result = await plugin.BuildAsync(new PersonaContext(rootPath, ir, inputs), ct);
                personasMeta.Add(new { result.PersonaId, result.Title, result.Metadata });
                if (!string.IsNullOrWhiteSpace(result.FramingMarkdown))
                {
                    if (personaFraming.Length > 0) personaFraming += "\n\n";
                    personaFraming += result.FramingMarkdown;
                }
            }
        }
        prompt.Personas = personaFraming;

        //var mode = cfg.Personas?.Mode?.ToLowerInvariant() ?? "append";
        //string framingInput = compiledViews;
        //if (!string.IsNullOrEmpty(personaFraming))
        //{
        //    framingInput = mode switch
        //    {
        //        "prepend" => personaFraming + "\n\n" + compiledViews,
        //        "replace" => personaFraming,
        //        _ => compiledViews + "\n\n" + personaFraming,
        //    };
        //}

        var template = plugins.Templates.OrderBy(t => t.Metadata.Priority).FirstOrDefault();
        if(template is null)
            throw new InvalidOperationException("No prompt template plugins are registered.");

        var finalPrompt = template.Apply(options, prompt);

        if (finalPrompt.Length > options.MaxCharacters)
            finalPrompt = finalPrompt[..options.MaxCharacters] + "\n\n<!-- truncated by Context Compiler -->\n";

        // Graph
        var graph = new GraphModel();
        foreach (var frag in ir.Fragments)
        {
            graph.Nodes.Add(new GraphNode(frag.Evidence.EvidenceKey, "Evidence", frag.Evidence.EvidenceKey, new Dictionary<string, string>
            {
                ["source"] = frag.Source.Path,
                ["locator"] = frag.Source.Locator ?? ""
            }));
            var srcId = "S-" + hasher.Sha256Hex(frag.Source.Path)[..10];
            if (!graph.Nodes.Any(n => n.Id == srcId))
                graph.Nodes.Add(new GraphNode(srcId, "Source", Path.GetFileName(frag.Source.Path), new Dictionary<string, string> { { "path", frag.Source.Path } }));
            graph.Edges.Add(new GraphEdge(frag.Evidence.EvidenceKey, srcId, "DerivedFrom"));
        }

        var artifacts = new Dictionary<string, string>();

        void WriteArtifact(string name, string content)
        {
            var p = Path.Combine(outputPath, name);
            fs.WriteAllText(p, content);
            artifacts[name] = p;
        }

        await outputPlugins.Run(ct);

        WriteArtifact("prompt.context.md", finalPrompt);

        var evidenceIndex = ir.Fragments.Select(f => new
        {
            ek = f.Evidence.EvidenceKey,
            er = f.Evidence.EvidenceRevision,
            source = new { path = f.Source.Path, locator = f.Source.Locator },
            tags = f.Tags
        }).ToList();

        logger.LogInformation("Writing {Count} evidence items to index.", evidenceIndex.Count);
        WriteArtifact("evidence.index.json", JsonSerializer.Serialize(evidenceIndex, s_jsonIndentedOptions));

        WriteArtifact("reasoning.graph.json", JsonSerializer.Serialize(graph, s_jsonIndentedOptions));

        var secMd = "# Security Report\n\n" + (findings.Count == 0 ? "No findings." :
            string.Join("\n", findings.Select(f => $"- **{f.Severity}** `{f.PassId}` ({f.Action}): {f.Message} — `{f.EvidenceRef?.Path}`")));
        WriteArtifact("security.report.md", secMd);

        //var health = new
        //{
        //    fragments = ir.Fragments.Count,
        //    findings = findings.Count,
        //    views = views.Count,
        //    score = Math.Max(0, 100 - findings.Count * 5)
        //};
        //WriteArtifact("context.health.json", JsonSerializer.Serialize(health, s_jsonIndentedOptions));

        foreach (var exp in plugins.GraphExporters.OrderBy(e => e.Metadata.Priority))
        {
            var content = exp.Export(graph);
            WriteArtifact("reasoning.graph" + exp.FileExtension, content);
        }

        foreach (var v in views)
            WriteArtifact($"view.{v.ViewId}.md", v.Rendered);

        if (!string.IsNullOrEmpty(personaFraming))
        {
            WriteArtifact("persona.framing.md", personaFraming);
            WriteArtifact("personas.active.json", JsonSerializer.Serialize(new { active = cfg.Personas!.Active, mode = cfg.Personas.Mode, results = personasMeta }, s_jsonIndentedOptions));
        }

        // Preflight
        var preflight = new List<IPipelineFinding>();
        foreach (var g in plugins.Guards.Where(g => g.Stage == DocumentStage.Preflight).OrderBy(g => g.Metadata.Priority))
            preflight.AddRange(await g.EvaluateAsync(new GuardContext(docCtxBuilder.InitNew().WithRelativePath("prompt").Build()), ct));

        if (preflight.Count > 0)
        {
            findings = findings.Concat(preflight).ToList();
            var preMd = "# Preflight Findings\n\n" + string.Join("\n", preflight.Select(f => $"- **{f.Severity}** `{f.PassId}` ({f.Action}): {f.Message}"));
            WriteArtifact("preflight.report.md", preMd);
        }

        //return new GlobalCompileOutputs(artifacts, graph, findings);
    }

    private static string RenderGlobalContext(ContextConfig ctx)
    {
        var sb = new System.Text.StringBuilder();
        if (ctx.Project is not null)
        {
            sb.AppendLine("# Project");
            if (!string.IsNullOrWhiteSpace(ctx.Project.Name)) sb.AppendLine(CultureInfo.InvariantCulture, $"- Name: {ctx.Project.Name}");
            if (!string.IsNullOrWhiteSpace(ctx.Project.Summary)) sb.AppendLine(CultureInfo.InvariantCulture, $"- Summary: {ctx.Project.Summary}");
            if (!string.IsNullOrWhiteSpace(ctx.Project.Domain)) sb.AppendLine(CultureInfo.InvariantCulture, $"- Domain: {ctx.Project.Domain}");
            if (ctx.Project.Audience is not null && ctx.Project.Audience.Count > 0)
                sb.AppendLine("- Audience: " + string.Join(", ", ctx.Project.Audience));
            sb.AppendLine();
        }
        if (ctx.Objectives is not null && ctx.Objectives.Count > 0)
        {
            sb.AppendLine("# Objectives");
            foreach (var o in ctx.Objectives) sb.AppendLine("- " + o);
            sb.AppendLine();
        }
        if (ctx.Assumptions is not null && ctx.Assumptions.Count > 0)
        {
            sb.AppendLine("# Assumptions");
            foreach (var a in ctx.Assumptions) sb.AppendLine("- " + a);
            sb.AppendLine();
        }
        if (ctx.Constraints is not null)
        {
            if (ctx.Constraints.Must is not null && ctx.Constraints.Must.Count > 0)
            {
                sb.AppendLine("# Constraints — MUST");
                foreach (var m in ctx.Constraints.Must) sb.AppendLine("- " + m);
                sb.AppendLine();
            }
            if (ctx.Constraints.MustNot is not null && ctx.Constraints.MustNot.Count > 0)
            {
                sb.AppendLine("# Constraints — MUST NOT");
                foreach (var mn in ctx.Constraints.MustNot) sb.AppendLine("- " + mn);
                sb.AppendLine();
            }
        }
        if (ctx.Glossary is not null && ctx.Glossary.Count > 0)
        {
            sb.AppendLine("# Glossary");
            foreach (var kv in ctx.Glossary) sb.AppendLine(CultureInfo.InvariantCulture, $"- {kv.Key}: {kv.Value}");
            sb.AppendLine();
        }
        if (ctx.OutputContract is not null)
        {
            sb.AppendLine("# Output Contract");
            if (!string.IsNullOrWhiteSpace(ctx.OutputContract.Format)) sb.AppendLine(CultureInfo.InvariantCulture, $"- Format: {ctx.OutputContract.Format}");
            if (ctx.OutputContract.Sections is not null && ctx.OutputContract.Sections.Count > 0)
                sb.AppendLine("- Sections: " + string.Join(", ", ctx.OutputContract.Sections));
            if (ctx.OutputContract.Style is not null)
            {
                if (!string.IsNullOrWhiteSpace(ctx.OutputContract.Style.Tone)) sb.AppendLine(CultureInfo.InvariantCulture, $"- Tone: {ctx.OutputContract.Style.Tone}");
                if (!string.IsNullOrWhiteSpace(ctx.OutputContract.Style.Language)) sb.AppendLine(CultureInfo.InvariantCulture, $"- Language: {ctx.OutputContract.Style.Language}");
            }
            sb.AppendLine();
        }
        return sb.ToString().Trim();
    }
}
