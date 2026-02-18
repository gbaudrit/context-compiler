using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Plugins.Abstractions;

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
    IPrompt prompt,
    IOutput output,
    IGuardian guardian) : IGlobalPipelineRunner
{

    public async ValueTask RunAsync(
        string rootPath,
        string outputPath,
        bool cleanOutput,
        IReasoningIr ir,
        IReadOnlyList<IPipelineFinding> findings,
        CompileOptions options,
        IOutput output,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        fs.EnsureDirectory(outputPath, cleanOutput);

        ICtxcConfig cfg = cfgProvider.Current;

        await Task.WhenAll(plugins.GlobalPipelinePlugins.OrderBy(c => c.Metadata.Kind).Select(async p =>
        {
            logger.LogInformation("Running global pipeline plugin: {PluginName} (Kind: {PluginKind}, Priority: {PluginPriority})",
                p.Metadata.Id, p.Metadata.Kind, p.Metadata.Priority);
            await p.Run(ct);
        }));


        //// Global Context rendering (before personas)
        //if (cfg.Context?.Enabled == true)
        //{
        //    RenderGlobalContext(cfg.Context, prompt);
        //}

        //var template = plugins.Templates.OrderBy(t => t.Metadata.Priority).FirstOrDefault();
        //if (template is null)
        //    throw new InvalidOperationException("No prompt template plugins are registered.");

        //await Task.WhenAll(plugins.PromptRenderers.OrderBy(c => c.Metadata.Priority).Select(async renderer =>
        //{
        //    foreach(var rendererName in cfgProvider.Current.Renderers)
        //    {
        //        await renderer.RenderTemplateAsync(rendererName, rendererName, ct);
        //    }
        //}));

        //var finalPrompt = template.Apply(options, prompt);

        //if (finalPrompt.Length > options.MaxCharacters)
        //    finalPrompt = finalPrompt[..options.MaxCharacters] + "\n\n<!-- truncated by Context Compiler -->\n";

        // Graph


        //var artifacts = new Dictionary<string, string>();

        //void WriteArtifact(string name, string content)
        //{
        //    var p = Path.Combine(outputPath, name);
        //    fs.WriteAllText(p, content);
        //    artifacts[name] = p;
        //}

        //// Preflight
        //var preflight = new List<IPipelineFinding>();
        //foreach (var g in plugins.Guards.Where(g => g.Stage == DocumentStage.Preflight).OrderBy(g => g.Metadata.Priority))
        //    preflight.AddRange(await g.EvaluateAsync(new GuardContext(docCtxBuilder.InitNew().WithRelativePath("prompt").Build()), ct));

        //if (preflight.Count > 0)
        //{
        //    findings = findings.Concat(preflight).ToList();
        //    var preMd = "# Preflight Findings\n\n" + string.Join("\n", preflight.Select(f => $"- **{f.Severity}** `{f.PassId}` ({f.Action}): {f.Message}"));
        //    WriteArtifact("preflight.report.md", preMd);
        //}

        //foreach (var p in plugins.OutputArtifactComposers.OrderBy(e => e.Metadata.Priority))
        //{
        //    await p.Run(ct);
        //}

        //foreach (var p in plugins.OutputArtifactWriters.OrderBy(e => e.Metadata.Priority))
        //{
        //    await p.Run(ct);
        //}

        //return new GlobalCompileOutputs(artifacts, graph, findings);
    }

    //private static string RenderGlobalContext(ContextConfig ctx, IPrompt prompt)
    //{
    //    var sb = new System.Text.StringBuilder();
    //    //if (ctx.Project is not null)
    //    //{
    //    //    prompt.Name = ctx.Project.Name ?? string.Empty;
    //    //    prompt.Summary = ctx.Project.Summary ?? string.Empty;
    //    //    prompt.Domain = ctx.Project.Domain ?? string.Empty;
    //    //    prompt.Audiences = [.. ctx.Project.Audiences?.Select(a => new Audience() { Name = a.Key, Description = a.Value }).ToList() ?? []];

    //    //}

    //    //prompt.Objectives = [.. ctx.Objectives?.Select(o => new Objective() { Name = o.Key, Description = o.Value }).ToList() ?? []];
    //    //prompt.Assumptions = [.. ctx.Assumptions?.Select(a => new Assumption() { Name = a.Key, Description = a.Value }).ToList() ?? []];
    //    //prompt.MustConstraints = [.. ctx.Constraints?.Must?.Select(m => new MustConstraint() { Text = m }) ?? []];
    //    //prompt.MustNotConstraints = [.. ctx.Constraints?.MustNot?.Select(m => new MustNotConstraint() { Text = m }) ?? []];
    //    //prompt.Glossary = [.. ctx.Glossary?.Select(kv => new GlossaryTerm() { Term = kv.Key, Definition = kv.Value }) ?? []];


    //    if (ctx.OutputContract is not null)
    //    {
    //        sb.AppendLine("# Output Contract");
    //        if (!string.IsNullOrWhiteSpace(ctx.OutputContract.Format)) sb.AppendLine(CultureInfo.InvariantCulture, $"- Format: {ctx.OutputContract.Format}");
    //        if (ctx.OutputContract.Sections is not null && ctx.OutputContract.Sections.Count > 0)
    //            sb.AppendLine("- Sections: " + string.Join(", ", ctx.OutputContract.Sections));
    //        if (ctx.OutputContract.Style is not null)
    //        {
    //            if (!string.IsNullOrWhiteSpace(ctx.OutputContract.Style.Tone)) sb.AppendLine(CultureInfo.InvariantCulture, $"- Tone: {ctx.OutputContract.Style.Tone}");
    //            if (!string.IsNullOrWhiteSpace(ctx.OutputContract.Style.Language)) sb.AppendLine(CultureInfo.InvariantCulture, $"- Language: {ctx.OutputContract.Style.Language}");
    //        }
    //        sb.AppendLine();
    //    }
    //    return sb.ToString().Trim();
    //}
}
