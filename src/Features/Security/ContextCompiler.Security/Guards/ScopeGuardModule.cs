using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.FileSystemGlobbing;

namespace ContextCompiler.Security.Guards;

public sealed class ScopeGuardModule() : IInputIngestionPipelineModule
{
    public InputIngestionModuleMetadata Metadata => IInputIngestionPipelineModule.Meta("security.guard.scope", InputIngestionPipelineModuleKinds.ReadScopeGuards, priority: -100);
    //public DocumentStage Stage => DocumentStage.Discovery;

    private static readonly string[] Excludes =
    [
        "**/.git/**",
        "**/.ctxc/**",
        "**/bin/**",
        "**/obj/**"
    ];

    public bool CanProcess(IInputItemContext InputItemContext)
    {
        return true;
    }

    public Task<IResult<IInputIngestionPipelineRunResult>> Run(IInputIngestionPipelineRunContext context, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        if (context.InputItem.Data is null)
        {
            return context.NothingToDo();
        }

        Matcher matcher = new(StringComparison.OrdinalIgnoreCase);
        //_ = matcher.AddInclude("**/*");
        foreach (string ex in Excludes)
        {
            _ = matcher.AddExclude(ex);
        }

        string rel = Path.GetRelativePath(context.InputItem.InputRoot, context.InputItem.Uri.AbsolutePath);
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
