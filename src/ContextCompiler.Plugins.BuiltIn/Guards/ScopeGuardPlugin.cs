using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

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
        if (ctx.DocumentContext is null) return Task.FromResult<IReadOnlyList<IPipelineFinding>>(Array.Empty<IPipelineFinding>());

        var matcher = new Matcher(StringComparison.OrdinalIgnoreCase);
        matcher.AddInclude("**/*");
        foreach (var ex in Excludes) matcher.AddExclude(ex);

        var rel = Path.GetRelativePath(ctx.DocumentContext.InputRoot, ctx.DocumentContext.FullPath);
        var match = matcher.Match(rel);
        if (!match.HasMatches)
        {
            return Task.FromResult<IReadOnlyList<IPipelineFinding>>(new []
            {
                ctx.DocumentContext.AddFinding(FindingSeverity.Info, FindingAction.Skip,"CtxGuard.Scope", 
                    "File excluded by scope rules.", new SourceRef(ctx.DocumentContext.FullPath))
            });
        }

        return Task.FromResult<IReadOnlyList<IPipelineFinding>>(Array.Empty<IPipelineFinding>());
    }
}
