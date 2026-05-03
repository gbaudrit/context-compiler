namespace ContextCompiler.Abstractions.Pipelines.Document;

public interface IDocumentPipelineRunResultBuilder
{
    IDocumentPipelineRunResult Build();
    IDocumentPipelineRunResultBuilder InitNew();
    IDocumentPipelineRunResultBuilder WithPatch(IDocumentContextPatch patch);
}
