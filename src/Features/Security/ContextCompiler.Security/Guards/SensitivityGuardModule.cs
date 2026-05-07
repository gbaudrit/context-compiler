using System.Text.RegularExpressions;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules.Security.Guards;

public sealed partial class SensitivityGuardModule(ISourceRefBuilder sourceRefBuilder) : IInputIngestionPipelineModule
{
    public InputIngestionModuleMetadata Metadata => IInputIngestionPipelineModule.Meta("security.guard.sensitivity", InputIngestionPipelineModuleKinds.ReadScopeGuards, priority: 10);

    private static readonly Regex SecretLike = SecretPattern();

    public bool CanProcess(IInputItemContext InputItemContext)
    {
        return true;
    }

    public Task<IResult<IInputIngestionPipelineRunResult>> Run(IInputIngestionPipelineRunContext context, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        if (context.InputItem is null
            || string.IsNullOrWhiteSpace(context.InputItem.InputRoot)
            || context.InputItem.Data.DataEnvelope is null)
        {
            return context.NothingToDo();
        }

        foreach (IDataPart part in context.InputItem.Data.DataEnvelope.Parts)
        {
            if (SecretLike.IsMatch(part.Payload.ToString() ?? ""))
            {
                context.AddFinding(FindingSeverity.Critical,
                                   FindingAction.Redact,
                                   "CtxGuard.Sensitivity",
                                   "Potential secret/token detected in context.");
            }
        }

        return context.Success();
    }

    [GeneratedRegex(@"(?i)\b(api[_-]?key|secret|token|password)\b\s*[:=]\s*\S+", RegexOptions.Compiled, "fr-FR")]
    private static partial Regex SecretPattern();
}
