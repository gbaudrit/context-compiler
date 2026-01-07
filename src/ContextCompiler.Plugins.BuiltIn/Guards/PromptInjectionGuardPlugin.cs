using System.Text.RegularExpressions;

using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.Guards;

public sealed class PromptInjectionGuardPlugin : IGuardPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.guard.injection", PluginKinds.Guard, priority: 0);
    public DocumentStage Stage => DocumentStage.ContentGuards;

    private static readonly Regex Pattern = new(@"(?i)\b(ignore|disregard)\b.{0,60}\b(previous|all|any)\b.{0,30}\b(instructions|rules)\b",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public Task<IReadOnlyList<IPipelineFinding>> EvaluateAsync(IGuardContext ctx, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        if (string.IsNullOrWhiteSpace(ctx.DocumentContext?.Content) || ctx.DocumentContext.FullPath is null) return Task.FromResult<IReadOnlyList<IPipelineFinding>>(Array.Empty<IPipelineFinding>());
        if (!Pattern.IsMatch(ctx.DocumentContext.Content)) return Task.FromResult<IReadOnlyList<IPipelineFinding>>(Array.Empty<IPipelineFinding>());

        return Task.FromResult<IReadOnlyList<IPipelineFinding>>(new[]
        {
            ctx.DocumentContext.AddFinding(FindingSeverity.Critical, FindingAction.Quarantine,"CtxGuard.Inject",
                "Prompt-injection-like instruction detected.", new SourceRef(ctx.DocumentContext.FullPath))
        });
    }
}
