namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IDocumentPass
    {
        static DocumentPassMetadata Meta(
            string id,
            DocumentPipelineModuleKinds kind,
            DocumentStage stage,
            int priority = 0)
        {
            return new(id, kind, stage, priority);
        }

        DocumentPassMetadata Metadata { get; }
        ValueTask ExecuteAsync(IDocumentContext ctx, CancellationToken ct);
    }
}
