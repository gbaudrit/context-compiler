using System.Text.RegularExpressions;
using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.Guards;

public sealed class SensitivityGuardPlugin : IGuardPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.guard.sensitivity", PluginKinds.Guard, priority: 10);
    public DocumentStage Stage => DocumentStage.ContentGuards;

    private static readonly Regex Email = new(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private static readonly Regex SecretLike = new(@"(?i)\b(api[_-]?key|secret|token|password)\b\s*[:=]\s*\S+", RegexOptions.Compiled);

    public Task<IReadOnlyList<IPipelineFinding>> EvaluateAsync(IGuardContext ctx, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        if (ctx.DocumentContext is null || string.IsNullOrWhiteSpace(ctx.DocumentContext.InputRoot)) return Task.FromResult<IReadOnlyList<IPipelineFinding>>(Array.Empty<IPipelineFinding>());
        var findings = new List<IPipelineFinding>();

        if (Email.IsMatch(ctx.DocumentContext.Content))
            findings.Add(ctx.DocumentContext.AddFinding(FindingSeverity.Warning, FindingAction.Warn, "CtxGuard.Sensitivity",
                "Potential email address detected in context.", new SourceRef(ctx.DocumentContext.FullPath)));

        if (SecretLike.IsMatch(ctx.DocumentContext.Content))
            findings.Add(ctx.DocumentContext.AddFinding(FindingSeverity.Critical, FindingAction.Redact, "CtxGuard.Sensitivity",
                "Potential secret/token detected in context.", new SourceRef(ctx.DocumentContext.FullPath)));

        return Task.FromResult<IReadOnlyList<IPipelineFinding>>(findings);
    }
}
