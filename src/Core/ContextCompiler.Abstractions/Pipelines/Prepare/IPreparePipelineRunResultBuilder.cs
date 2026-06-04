using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Abstractions.Pipelines.Prepare;

public interface IPreparePipelineRunResultBuilder
{
    IPreparePipelineRunResult Build();
    IPreparePipelineRunResultBuilder InitNew();
    IPreparePipelineRunResultBuilder WithInventory(ProjectInventory? inventory);
    IPreparePipelineRunResultBuilder WithClassification(ProjectClassification? classification);
    IPreparePipelineRunResultBuilder WithPlan(PreparePlan? plan);
}
