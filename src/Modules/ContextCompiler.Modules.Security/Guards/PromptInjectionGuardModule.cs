using System.Text.RegularExpressions;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules.Security.Guards;

public sealed partial class PromptInjectionGuardModule(ISourceRefBuilder sourceRefBuilder) : IDocumentPipelineModule
{
    public DocumentModuleMetadata Metadata => IDocumentPipelineModule.Meta("security.guard.injection", DocumentPipelineModuleKinds.ReadScopeGuards, priority: 0);
    //public DocumentStage Stage => DocumentStage.ContentGuards;

    private static readonly Regex Pattern = PromptInjectionPattern();

    public bool CanProcess(IDocumentContext documentContext)
    {
        return true;
    }

    public Task<IDocumentContextPatch> Run(IDocumentContext documentContext, IDocumentContextPatchBuilder patcher, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        List<IPipelineFinding> findings = [];
        if (documentContext.Data.DataEnvelope is null)
        {
            return patcher.NoChangesAsTask();
        }

        foreach (IDataPart part in documentContext.Data.DataEnvelope.Parts)
        {
            if (Pattern.IsMatch(part.Payload.ToString() ?? ""))
            {
                _ = patcher.AddFinding(FindingSeverity.Critical, FindingAction.Quarantine, "CtxGuard.Inject",
                "Prompt-injection-like instruction detected.", sourceRefBuilder.InitNew().WithPath(documentContext.FullPath).Build());
            }
        }

        return patcher.WithFindings(findings).BuildAsTask();
    }

    [GeneratedRegex(@"(?i)\b(ignore|disregard)\b.{0,60}\b(previous|all|any)\b.{0,30}\b(instructions|rules)\b", RegexOptions.Compiled | RegexOptions.CultureInvariant)]
    private static partial Regex PromptInjectionPattern();
}
