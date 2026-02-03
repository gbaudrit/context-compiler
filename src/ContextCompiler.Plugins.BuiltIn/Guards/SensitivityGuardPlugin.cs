using System.Text.RegularExpressions;

using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.Guards;

public sealed partial class SensitivityGuardPlugin : IGuardPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.guard.sensitivity", GlobalPipelinePluginKinds.Guard, priority: 10);
    public DocumentStage Stage => DocumentStage.ContentGuards;

    private static readonly Regex Email = EmailPattern();
    private static readonly Regex SecretLike = SecretPattern();

    public async Task<IReadOnlyList<IPipelineFinding>> EvaluateAsync(IGuardContext ctx, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        if (ctx.DocumentContext is null || string.IsNullOrWhiteSpace(ctx.DocumentContext.InputRoot))
        {
            return [];
        }

        List<IPipelineFinding> findings = [];
        if (ctx.DocumentContext.Data is null)
        {
            return findings;
        }

        foreach (IDataPart part in ctx.DocumentContext.Data.Parts)
        {
            if (Email.IsMatch(part.Payload.ToString() ?? ""))
            {
                findings.Add(ctx.DocumentContext.AddFinding(FindingSeverity.Warning, FindingAction.Warn, "CtxGuard.Sensitivity",
                    "Potential email address detected in context.", new SourceRef(ctx.DocumentContext.FullPath)));
            }

            if (SecretLike.IsMatch(part.Payload.ToString() ?? ""))
            {
                findings.Add(ctx.DocumentContext.AddFinding(FindingSeverity.Critical, FindingAction.Redact, "CtxGuard.Sensitivity",
                    "Potential secret/token detected in context.", new SourceRef(ctx.DocumentContext.FullPath)));
            }
        }

        return findings;
    }

    [GeneratedRegex(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}", RegexOptions.IgnoreCase | RegexOptions.Compiled, "fr-FR")]
    private static partial Regex EmailPattern();

    [GeneratedRegex(@"(?i)\b(api[_-]?key|secret|token|password)\b\s*[:=]\s*\S+", RegexOptions.Compiled, "fr-FR")]
    private static partial Regex SecretPattern();
}
