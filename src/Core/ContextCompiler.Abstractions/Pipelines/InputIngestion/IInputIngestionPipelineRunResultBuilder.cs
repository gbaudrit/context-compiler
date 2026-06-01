namespace ContextCompiler.Abstractions.Pipelines.InputIngestion;

public interface IInputIngestionPipelineRunResultBuilder
{
    IInputIngestionPipelineRunResult Build();
    IInputIngestionPipelineRunResultBuilder InitNew();
    IInputIngestionPipelineRunResultBuilder WithPatch(IInputItemContextPatch patch);
}
