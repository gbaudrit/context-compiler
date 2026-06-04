namespace ContextCompiler.Abstractions.Pipelines.Compile;

public interface ICompilePipelineRunResultBuilder
{
    ICompilePipelineRunResult Build();
    ICompilePipelineRunResultBuilder InitNew();
}
