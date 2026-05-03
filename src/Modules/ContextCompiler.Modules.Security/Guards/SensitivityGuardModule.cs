using System.Text.RegularExpressions;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules.Security.Guards;

public sealed partial class SensitivityGuardModule(ISourceRefBuilder sourceRefBuilder) : IDocumentPipelineModule
{
    public DocumentModuleMetadata Metadata => IDocumentPipelineModule.Meta("security.guard.sensitivity", DocumentPipelineModuleKinds.ReadScopeGuards, priority: 10);

    private static readonly Regex SecretLike = SecretPattern();

    public bool CanProcess(IDocumentContext documentContext)
    {
        return true;
    }

    public Task<IResult<IDocumentPipelineRunResult>> Run(IDocumentPipelineRunContext context, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        if (context.Document is null
            || string.IsNullOrWhiteSpace(context.Document.InputRoot)
            || context.Document.Data.DataEnvelope is null)
        {
            return context.NothingToDo();
        }

        foreach (IDataPart part in context.Document.Data.DataEnvelope.Parts)
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
