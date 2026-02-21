using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Modules.Abstractions;

public interface IGuardModule : IModule
{
    DocumentStage Stage { get; }
    Task<IReadOnlyList<IPipelineFinding>> EvaluateAsync(IGuardContext ctx, CancellationToken ct);
}

public sealed record GuardContext(
    IDocumentContext DocumentContext,
    IDataPart? Part = null
) : IGuardContext;
