namespace ContextCompiler.Abstractions.Pipelines;

public interface IGlobalPipelineRunContextBuilder
{
    IGlobalPipelineRunContext Build();
    IGlobalPipelineRunContextBuilder InitNew();
    IGlobalPipelineRunContextBuilder WithPipeline(IPipeline pipeline);
    IGlobalPipelineRunContextBuilder WithPhaseKey(string phaseKey);
}
