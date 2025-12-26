using System.Text.RegularExpressions;
using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.Guards;

public sealed class SensitivityGuardPlugin : IGuardPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.guard.sensitivity", PluginKinds.Guard, priority: 10);
    public GuardStage Stage => GuardStage.Fragment;

    private static readonly Regex Email = new(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private static readonly Regex SecretLike = new(@"(?i)\b(api[_-]?key|secret|token|password)\b\s*[:=]\s*\S+", RegexOptions.Compiled);

    public Task<IReadOnlyList<GuardFinding>> EvaluateAsync(GuardContext ctx, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        if (ctx.FilePath is null || string.IsNullOrWhiteSpace(ctx.Text)) return Task.FromResult<IReadOnlyList<GuardFinding>>(Array.Empty<GuardFinding>());
        var findings = new List<GuardFinding>();

        if (Email.IsMatch(ctx.Text))
            findings.Add(new GuardFinding("CtxGuard.Sensitivity", GuardSeverity.Warning, GuardActionKind.Warn,
                "Potential email address detected in context.", new SourceRef(ctx.FilePath)));

        if (SecretLike.IsMatch(ctx.Text))
            findings.Add(new GuardFinding("CtxGuard.Sensitivity", GuardSeverity.Error, GuardActionKind.Redact,
                "Potential secret/token detected in context.", new SourceRef(ctx.FilePath)));

        return Task.FromResult<IReadOnlyList<GuardFinding>>(findings);
    }
}
