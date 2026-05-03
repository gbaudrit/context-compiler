namespace ContextCompiler.Abstractions.Pipelines.Document;

public interface IDocumentPipelineRunContextBuilder
{
    IDocumentPipelineRunContext Build();
    IDocumentPipelineRunContextBuilder InitNew();
    IDocumentPipelineRunContextBuilder WithPipeline(IPipeline pipeline);
    IDocumentPipelineRunContextBuilder WithDocumentContext(IDocumentContext documentContext);
    IDocumentPipelineRunContextBuilder WithPatchContext(IDocumentContextPatchBuilder patchContext);
}
