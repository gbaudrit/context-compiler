namespace ContextCompiler.Abstractions.Pipelines.Compile;

public interface ICompilePipelineRunContextBuilder
{
    ICompilePipelineRunContext Build();
    ICompilePipelineRunContextBuilder InitNew();
    ICompilePipelineRunContextBuilder WithPipeline(IPipeline pipeline);
    ICompilePipelineRunContextBuilder WithPhaseKey(string phaseKey);
}
