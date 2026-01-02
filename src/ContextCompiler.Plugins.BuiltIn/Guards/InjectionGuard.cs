using System.Text.RegularExpressions;
using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Plugins.BuiltIn.Guards;

public sealed class InjectionGuard : IInjectionGuard
{
    // TODO: move to IGuardPlugin + stage hooks
    private static readonly Regex HardIgnore = new(@"(?i)\bignore\b.{0,40}\b(previous|all|any)\b.{0,20}\b(instructions|rules)\b",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public GuardFinding? Scan(string path, string content)
    {
        if (!HardIgnore.IsMatch(content)) return null;
        return new GuardFinding(
            GuardId: "CtxGuard.Inject",
            Severity: GuardSeverity.Error,
            Action: GuardActionKind.Quarantine,
            Message: "Prompt-injection-like instruction detected.",
            Source: new SourceRef(path),
            Data: new Dictionary<string, object> { ["match"] = "ignore previous instructions" }
        );
    }
}
