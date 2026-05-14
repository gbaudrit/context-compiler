using System.Text.RegularExpressions;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Security.Guards;

namespace ContextCompiler.Modules.Security.Guards;

public sealed partial class InjectionGuard(ISourceRefBuilder sourceRefBuilder) : IInjectionGuard
{
    private static readonly Regex HardIgnore = PromptInjectionPattern();

    public GuardFinding? Scan(Uri uri, string content)
    {
        return !HardIgnore.IsMatch(content)
            ? null
            : new GuardFinding(
            GuardId: "CtxGuard.Inject",
            Severity: GuardSeverity.Error,
            Action: GuardActionKind.Quarantine,
            Message: "Prompt-injection-like instruction detected.",
            Source: sourceRefBuilder.InitNew().WithUri(uri).Build(),
            Data: new Dictionary<string, object> { ["match"] = "ignore previous instructions" }
        );
    }

    [GeneratedRegex(@"(?i)\bignore\b.{0,40}\b(previous|all|any)\b.{0,20}\b(instructions|rules)\b", RegexOptions.Compiled | RegexOptions.CultureInvariant)]
    private static partial Regex PromptInjectionPattern();
}
