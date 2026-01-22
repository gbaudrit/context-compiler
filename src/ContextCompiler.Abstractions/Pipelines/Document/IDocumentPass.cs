namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IDocumentPass
    {
        string Id { get; }
        int Priority { get; }               // deterministic ordering inside a stage
        DocumentStage Stage { get; }
        ValueTask ExecuteAsync(IDocumentContext ctx, CancellationToken ct);
    }
}
