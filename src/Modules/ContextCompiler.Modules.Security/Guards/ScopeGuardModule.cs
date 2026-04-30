using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.FileSystemGlobbing;

namespace ContextCompiler.Modules.Security.Guards;

public sealed class ScopeGuardModule(ISourceRefBuilder sourceRefBuilder) : IDocumentPipelineModule
{
    public DocumentModuleMetadata Metadata => IDocumentPipelineModule.Meta("security.guard.scope", DocumentPipelineModuleKinds.ReadScopeGuards, priority: -100);
    //public DocumentStage Stage => DocumentStage.Discovery;

    private static readonly string[] Excludes =
    [
        "**/.git/**",
        "**/.ctxboost/**",
        "**/bin/**",
        "**/obj/**"
    ];

    public bool CanProcess(IDocumentContext documentContext)
    {
        return true;
    }

    public Task<IDocumentContextPatch> Run(IDocumentContext documentContext, IDocumentContextPatchBuilder patcher, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        if (documentContext.Data is null)
        {
            return patcher.NoChangesAsTask();
        }

        Matcher matcher = new(StringComparison.OrdinalIgnoreCase);
        _ = matcher.AddInclude("**/*");
        foreach (string ex in Excludes)
        {
            _ = matcher.AddExclude(ex);
        }

        string rel = Path.GetRelativePath(documentContext.InputRoot, documentContext.FullPath);
        PatternMatchingResult match = matcher.Match(rel);
        return !match.HasMatches
            ? patcher.AddFinding(FindingSeverity.Info, FindingAction.Skip, "CtxGuard.Scope",
                    "File excluded by scope rules.", sourceRefBuilder.InitNew().WithPath(documentContext.FullPath).Build()).BuildAsTask()
            : patcher.NoChangesAsTask();
    }
}
