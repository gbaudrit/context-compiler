using ContextCompiler.Abstractions.Models.Analyze;

namespace ContextCompiler.Abstractions.Pipelines.Analyze;

public interface IAnalyzePipelineRunContextBuilder
{
    IAnalyzePipelineRunContext Build();
    IAnalyzePipelineRunContextBuilder InitNew();
    IAnalyzePipelineRunContextBuilder WithPipeline(IPipeline pipeline);
    IAnalyzePipelineRunContextBuilder WithPhaseKey(string phaseKey);
    IAnalyzePipelineRunContextBuilder WithRequest(AnalyzeRequest request);
}
