using System.Text.RegularExpressions;

using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.Guards;

public sealed class PromptInjectionGuardPlugin : IGuardPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.guard.injection", GlobalPipelinePluginKinds.Guard, priority: 0);
    public DocumentStage Stage => DocumentStage.ContentGuards;

    private static readonly Regex Pattern = new(@"(?i)\b(ignore|disregard)\b.{0,60}\b(previous|all|any)\b.{0,30}\b(instructions|rules)\b",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public async Task<IReadOnlyList<IPipelineFinding>> EvaluateAsync(IGuardContext ctx, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        List<IPipelineFinding> findings = new();
        if (ctx.DocumentContext.Data is null) return findings;

        foreach (IDataPart part in ctx.DocumentContext.Data.Parts)
        {
            if (Pattern.IsMatch(part.Payload.ToString() ?? ""))
            {
                ctx.DocumentContext.AddFinding(FindingSeverity.Critical, FindingAction.Quarantine, "CtxGuard.Inject",
                "Prompt-injection-like instruction detected.", new SourceRef(ctx.DocumentContext.FullPath));
            }
        }

        return findings;
    }
}
