namespace ContextCompiler.Abstractions.Pipelines.InputIngestion;

public interface IInputIngestionPipelineRunContextBuilder
{
    IInputIngestionPipelineRunContext Build();
    IInputIngestionPipelineRunContextBuilder InitNew();
    IInputIngestionPipelineRunContextBuilder WithParent(IPipelineRunContext parent);
    IInputIngestionPipelineRunContextBuilder WithPipeline(IPipeline pipeline);
    IInputIngestionPipelineRunContextBuilder WithInputItemContext(IInputItemContext inputItemContext);
    IInputIngestionPipelineRunContextBuilder WithPatchContext(IInputItemContextPatchBuilder patchContext);
}
