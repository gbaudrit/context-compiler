using System.Text.RegularExpressions;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules.Security.Guards;

public sealed partial class PromptInjectionGuardModule(ISourceRefBuilder sourceRefBuilder) : IInputIngestionPipelineModule
{
    public InputIngestionModuleMetadata Metadata => IInputIngestionPipelineModule.Meta("security.guard.injection", InputIngestionPipelineModuleKinds.ReadScopeGuards, priority: 0);
    //public DocumentStage Stage => DocumentStage.ContentGuards;

    private static readonly Regex Pattern = PromptInjectionPattern();

    public bool CanProcess(IInputItemContext InputItemContext)
    {
        return true;
    }

    public Task<IResult<IInputIngestionPipelineRunResult>> Run(IInputIngestionPipelineRunContext context, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        if (context.InputItem.Data.DataEnvelope is null)
        {
            return context.NothingToDo();
        }

        foreach (IDataPart part in context.InputItem.Data.DataEnvelope.Parts)
        {
            if (Pattern.IsMatch(part.Payload.ToString() ?? ""))
            {
                context.AddFinding(FindingSeverity.Critical,
                                   FindingAction.Quarantine,
                                   "CtxGuard.Inject",
                                   "Prompt-injection-like instruction detected.");
            }
        }

        return context.Success();
    }

    [GeneratedRegex(@"(?i)\b(ignore|disregard)\b.{0,60}\b(previous|all|any)\b.{0,30}\b(instructions|rules)\b", RegexOptions.Compiled | RegexOptions.CultureInvariant)]
    private static partial Regex PromptInjectionPattern();
}
