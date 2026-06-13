using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models.Analyze;
using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Analyze;

namespace ContextCompiler.Core.Pipelines.Analyze;

internal sealed class AnalyzePipelineRunContext(
    IPipeline pipeline,
    string phaseKey,
    AnalyzeRequest request,
    IAnalyzePipelineRunResultBuilder resultBuilder) : IAnalyzePipelineRunContext
{
    public IPipeline Pipeline { get; } = pipeline;
    public string PhaseKey { get; } = phaseKey;
    public AnalyzeRequest Request { get; } = request;

    public ProjectInventory? Inventory { get; private set; }
    public ProjectClassification? Classification { get; private set; }
    public AnalyzePlan? Plan { get; private set; }

    public IAnalyzePipelineRunContext WithInventory(ProjectInventory inventory)
    {
        Inventory = inventory;
        return this;
    }

    public IAnalyzePipelineRunContext WithClassification(ProjectClassification classification)
    {
        Classification = classification;
        return this;
    }

    public IAnalyzePipelineRunContext WithPlan(AnalyzePlan plan)
    {
        Plan = plan;
        return this;
    }

    public Task<IResult<IAnalyzePipelineRunResult>> Success()
    {
        return Task.FromResult(IResult.Success(BuildResult()));
    }

    public Task<IResult<IAnalyzePipelineRunResult>> Failure(Exception ex)
    {
        return Task.FromResult(IResult.Failure(BuildResult(), ex.Message, ex));
    }

    public Task<IResult<IAnalyzePipelineRunResult>> Failure(string message)
    {
        return Task.FromResult(IResult.Failure(BuildResult(), message));
    }

    public Task<IResult<IAnalyzePipelineRunResult>> Failure(string message, Exception ex)
    {
        return Task.FromResult(IResult.Failure(BuildResult(), message, ex));
    }

    private IAnalyzePipelineRunResult BuildResult()
    {
        return resultBuilder
            .InitNew()
            .WithInventory(Inventory)
            .WithClassification(Classification)
            .WithPlan(Plan)
            .Build();
    }
}
