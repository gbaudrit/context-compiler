namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IDocumentPipelineRunner
    {
        ValueTask RunAsync(IDocumentsContext documentsContext, CancellationToken ct);
    }
}
