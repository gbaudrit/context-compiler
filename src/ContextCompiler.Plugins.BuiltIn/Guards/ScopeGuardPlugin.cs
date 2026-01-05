using Microsoft.Extensions.FileSystemGlobbing;
using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.Guards;

public sealed class ScopeGuardPlugin : IGuardPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.guard.scope", PluginKinds.Guard, priority: -100);
    public GuardStage Stage => GuardStage.Read;

    private static readonly string[] Excludes =
    [
        "**/.git/**",
        "**/.ctxboost/**",
        "**/bin/**",
        "**/obj/**"
    ];

    public Task<IReadOnlyList<GuardFinding>> EvaluateAsync(GuardContext ctx, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        if (ctx.FilePath is null) return Task.FromResult<IReadOnlyList<GuardFinding>>(Array.Empty<GuardFinding>());

        var matcher = new Matcher(StringComparison.OrdinalIgnoreCase);
        matcher.AddIncludePatterns(Excludes);

        var rel = Path.GetRelativePath(ctx.RootPath, ctx.FilePath);
        var match = matcher.Match(rel);
        if (match.HasMatches)
        {
            return Task.FromResult<IReadOnlyList<GuardFinding>>(new []
            {
                new GuardFinding("CtxGuard.Scope", GuardSeverity.Info, GuardActionKind.Skip,
                    "File excluded by scope rules.", new SourceRef(ctx.FilePath))
            });
        }

        return Task.FromResult<IReadOnlyList<GuardFinding>>(Array.Empty<GuardFinding>());
    }
}
