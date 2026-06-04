using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Pipelines.Prepare;

namespace ContextCompiler.Core.Pipelines.Prepare;

internal sealed class PreparePipelineRunResultBuilder : IPreparePipelineRunResultBuilder
{
    private ProjectInventory? _inventory;
    private ProjectClassification? _classification;
    private PreparePlan? _plan;

    public IPreparePipelineRunResultBuilder InitNew()
    {
        _inventory = null;
        _classification = null;
        _plan = null;
        return this;
    }

    public IPreparePipelineRunResultBuilder WithInventory(ProjectInventory? inventory)
    {
        _inventory = inventory;
        return this;
    }

    public IPreparePipelineRunResultBuilder WithClassification(ProjectClassification? classification)
    {
        _classification = classification;
        return this;
    }

    public IPreparePipelineRunResultBuilder WithPlan(PreparePlan? plan)
    {
        _plan = plan;
        return this;
    }

    public IPreparePipelineRunResult Build()
    {
        return new PreparePipelineRunResult(_inventory, _classification, _plan);
    }
}
