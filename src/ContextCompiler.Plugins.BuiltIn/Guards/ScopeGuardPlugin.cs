using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Plugins.Abstractions;

using Microsoft.Extensions.FileSystemGlobbing;

namespace ContextCompiler.Plugins.BuiltIn.Guards;

public sealed class ScopeGuardPlugin : IGuardPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.guard.scope", GlobalPipelinePluginKinds.Guard, priority: -100);
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
