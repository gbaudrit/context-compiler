namespace ContextCompiler.Abstractions.Pipelines;

public interface IGlobalPipelineRunResultBuilder
{
    IGlobalPipelineRunResult Build();
    IGlobalPipelineRunResultBuilder InitNew();
}
