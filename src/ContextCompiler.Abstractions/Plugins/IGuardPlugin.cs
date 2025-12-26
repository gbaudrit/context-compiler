using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Plugins;

public interface IGuardPlugin : IPlugin
{
    GuardStage Stage { get; }
    Task<IReadOnlyList<GuardFinding>> EvaluateAsync(GuardContext ctx, CancellationToken ct);
}

public sealed record GuardContext(
    string RootPath,
    string? FilePath = null,
    string? Text = null,
    DocumentContent? Document = null,
    DataEnvelope? Envelope = null,
    IReadOnlyList<string>? ViewIds = null
);
