using ContextCompiler.Abstractions.Models.Analyze;
using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Pipelines.Analyze;

namespace ContextCompiler.Core.Pipelines.Analyze;

internal sealed class AnalyzePipelineRunResultBuilder : IAnalyzePipelineRunResultBuilder
{
    private ProjectInventory? _inventory;
    private ProjectClassification? _classification;
    private AnalyzePlan? _plan;

    public IAnalyzePipelineRunResultBuilder InitNew()
    {
        _inventory = null;
        _classification = null;
        _plan = null;
        return this;
    }

    public IAnalyzePipelineRunResultBuilder WithInventory(ProjectInventory? inventory)
    {
        _inventory = inventory;
        return this;
    }

    public IAnalyzePipelineRunResultBuilder WithClassification(ProjectClassification? classification)
    {
        _classification = classification;
        return this;
    }

    public IAnalyzePipelineRunResultBuilder WithPlan(AnalyzePlan? plan)
    {
        _plan = plan;
        return this;
    }

    public IAnalyzePipelineRunResult Build()
    {
        return new AnalyzePipelineRunResult(_inventory, _classification, _plan);
    }
}
