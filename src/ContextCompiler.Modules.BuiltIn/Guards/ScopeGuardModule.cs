using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.FileSystemGlobbing;

namespace ContextCompiler.Modules.BuiltIn.Guards;

public sealed class ScopeGuardModule : IGuardModule
{
    public ModuleMetadata Metadata => BuiltInMetadata.Meta("builtin.guard.scope", GlobalPipelineModuleKinds.Guard, priority: -100);
    public DocumentStage Stage => DocumentStage.Discovery;

    private static readonly string[] Excludes =
    [
        "**/.git/**",
        "**/.ctxboost/**",
        "**/bin/**",
        "**/obj/**"
    ];

    public Task<IReadOnlyList<IPipelineFinding>> EvaluateAsync(IGuardContext ctx, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        if (ctx.DocumentContext is null)
        {
            return Task.FromResult<IReadOnlyList<IPipelineFinding>>([]);
        }

        Matcher matcher = new(StringComparison.OrdinalIgnoreCase);
        _ = matcher.AddInclude("**/*");
        foreach (string ex in Excludes)
        {
            _ = matcher.AddExclude(ex);
        }

        string rel = Path.GetRelativePath(ctx.DocumentContext.InputRoot, ctx.DocumentContext.FullPath);
        PatternMatchingResult match = matcher.Match(rel);
        return !match.HasMatches
            ? Task.FromResult<IReadOnlyList<IPipelineFinding>>(
            [
                ctx.DocumentContext.AddFinding(FindingSeverity.Info, FindingAction.Skip,"CtxGuard.Scope",
                    "File excluded by scope rules.", new SourceRef(ctx.DocumentContext.FullPath))
            ])
            : Task.FromResult<IReadOnlyList<IPipelineFinding>>([]);
    }
}
