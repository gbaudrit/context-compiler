using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Abstractions.Pipelines.Prepare;

public interface IPreparePipelineRunContextBuilder
{
    IPreparePipelineRunContext Build();
    IPreparePipelineRunContextBuilder InitNew();
    IPreparePipelineRunContextBuilder WithPipeline(IPipeline pipeline);
    IPreparePipelineRunContextBuilder WithPhaseKey(string phaseKey);
    IPreparePipelineRunContextBuilder WithRequest(PrepareRequest request);
}
