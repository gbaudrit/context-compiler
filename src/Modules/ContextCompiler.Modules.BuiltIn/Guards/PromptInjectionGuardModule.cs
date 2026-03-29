using System.Text.RegularExpressions;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules.BuiltIn.Guards;

public sealed partial class PromptInjectionGuardModule(ISourceRefBuilder sourceRefBuilder) : IGuardModule
{
    public ModuleMetadata Metadata => BuiltInMetadata.Meta("builtin.guard.injection", GlobalPipelineModuleKinds.Guard, priority: 0);
    public DocumentStage Stage => DocumentStage.ContentGuards;

    private static readonly Regex Pattern = PromptInjectionPattern();

    public Task<IReadOnlyList<IPipelineFinding>> EvaluateAsync(IGuardContext ctx, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        List<IPipelineFinding> findings = [];
        if (ctx.DocumentContext.Data is null)
        {
            return Task.FromResult<IReadOnlyList<IPipelineFinding>>(findings);
        }

        foreach (IDataPart part in ctx.DocumentContext.Data.Parts)
        {
            if (Pattern.IsMatch(part.Payload.ToString() ?? ""))
            {
                _ = ctx.DocumentContext.AddFinding(FindingSeverity.Critical, FindingAction.Quarantine, "CtxGuard.Inject",
                "Prompt-injection-like instruction detected.", sourceRefBuilder.InitNew().WithPath(ctx.DocumentContext.FullPath).Build());
            }
        }

        return Task.FromResult<IReadOnlyList<IPipelineFinding>>(findings);
    }

    [GeneratedRegex(@"(?i)\b(ignore|disregard)\b.{0,60}\b(previous|all|any)\b.{0,30}\b(instructions|rules)\b", RegexOptions.Compiled | RegexOptions.CultureInvariant)]
    private static partial Regex PromptInjectionPattern();
}
