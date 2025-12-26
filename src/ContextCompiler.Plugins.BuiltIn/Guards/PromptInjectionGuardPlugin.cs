using System.Text.RegularExpressions;
using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.Guards;

public sealed class PromptInjectionGuardPlugin : IGuardPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.guard.injection", PluginKinds.Guard, priority: 0);
    public GuardStage Stage => GuardStage.Fragment;

    private static readonly Regex Pattern = new(@"(?i)\b(ignore|disregard)\b.{0,60}\b(previous|all|any)\b.{0,30}\b(instructions|rules)\b",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public Task<IReadOnlyList<GuardFinding>> EvaluateAsync(GuardContext ctx, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        if (string.IsNullOrWhiteSpace(ctx.Text) || ctx.FilePath is null) return Task.FromResult<IReadOnlyList<GuardFinding>>(Array.Empty<GuardFinding>());
        if (!Pattern.IsMatch(ctx.Text)) return Task.FromResult<IReadOnlyList<GuardFinding>>(Array.Empty<GuardFinding>());

        return Task.FromResult<IReadOnlyList<GuardFinding>>(new []
        {
            new GuardFinding("CtxGuard.Inject", GuardSeverity.Error, GuardActionKind.Quarantine,
                "Prompt-injection-like instruction detected.", new SourceRef(ctx.FilePath))
        });
    }
}
