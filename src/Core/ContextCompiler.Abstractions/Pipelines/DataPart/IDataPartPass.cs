using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Abstractions.Pipelines.DataPart
{
    public interface IDataPartPass
    {
        string Id { get; }
        int Priority { get; }               // deterministic ordering inside a stage
        DocumentStage Stage { get; }
        ValueTask<IDocumentContextPatch> ExecuteAsync(IDocumentContext ctx, IDocumentContextPatchBuilder patcher, IDataPart part, CancellationToken ct);
    }
}
