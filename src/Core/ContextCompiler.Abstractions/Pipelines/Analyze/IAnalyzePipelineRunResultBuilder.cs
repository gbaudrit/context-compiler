using ContextCompiler.Abstractions.Models.Analyze;
using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Abstractions.Pipelines.Analyze;

public interface IAnalyzePipelineRunResultBuilder
{
    IAnalyzePipelineRunResult Build();
    IAnalyzePipelineRunResultBuilder InitNew();
    IAnalyzePipelineRunResultBuilder WithInventory(ProjectInventory? inventory);
    IAnalyzePipelineRunResultBuilder WithClassification(ProjectClassification? classification);
    IAnalyzePipelineRunResultBuilder WithPlan(AnalyzePlan? plan);
}
