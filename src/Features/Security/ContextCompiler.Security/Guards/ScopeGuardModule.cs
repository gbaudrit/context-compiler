using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.FileSystemGlobbing;

namespace ContextCompiler.Security.Guards;

public sealed class ScopeGuardModule() : IDocumentPipelineModule
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

    public Task<IResult<IDocumentPipelineRunResult>> Run(IDocumentPipelineRunContext context, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        if (context.Document.Data is null)
        {
            return context.NothingToDo();
        }

        Matcher matcher = new(StringComparison.OrdinalIgnoreCase);
        _ = matcher.AddInclude("**/*");
        foreach (string ex in Excludes)
        {
            _ = matcher.AddExclude(ex);
        }

        string rel = Path.GetRelativePath(context.Document.InputRoot, context.Document.FullPath);
        PatternMatchingResult match = matcher.Match(rel);

        if (match.HasMatches)
        {
            context.AddFinding(FindingSeverity.Info,
                               FindingAction.Skip,
                               "CtxGuard.Scope",
                               "File excluded by scope rules.");
        }

        return context.Success();
    }
}
