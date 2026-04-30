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

    public Task<IDocumentContextPatch> Run(IDocumentContext documentContext, IDocumentContextPatchBuilder patcher, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        if (documentContext is null || string.IsNullOrWhiteSpace(documentContext.InputRoot))
        {
            return patcher.NoChangesAsTask();
        }

        if (documentContext.Data.DataEnvelope is null)
        {
            return patcher.NoChangesAsTask();
        }

        foreach (IDataPart part in documentContext.Data.DataEnvelope.Parts)
        {
            if (SecretLike.IsMatch(part.Payload.ToString() ?? ""))
            {
                _ = patcher.AddFinding(FindingSeverity.Critical, FindingAction.Redact, "CtxGuard.Sensitivity",
                    "Potential secret/token detected in context.", sourceRefBuilder.InitNew().WithPath(documentContext.FullPath).Build());
            }
        }

        return patcher.BuildAsTask();
    }

    [GeneratedRegex(@"(?i)\b(api[_-]?key|secret|token|password)\b\s*[:=]\s*\S+", RegexOptions.Compiled, "fr-FR")]
    private static partial Regex SecretPattern();
}
