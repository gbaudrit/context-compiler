using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Prepare;

namespace ContextCompiler.Core.Pipelines.Prepare;

internal sealed class PreparePipelineRunContext(
    IPipeline pipeline,
    string phaseKey,
    PrepareRequest request,
    IPreparePipelineRunResultBuilder resultBuilder) : IPreparePipelineRunContext
{
    public IPipeline Pipeline { get; } = pipeline;
    public string PhaseKey { get; } = phaseKey;
    public PrepareRequest Request { get; } = request;

    public ProjectInventory? Inventory { get; private set; }

    public ProjectClassification? Classification { get; private set; }

    public PreparePlan? Plan { get; private set; }

    public IPreparePipelineRunContext WithInventory(ProjectInventory inventory)
    {
        Inventory = inventory;
        return this;
    }

    public IPreparePipelineRunContext WithClassification(ProjectClassification classification)
    {
        Classification = classification;
        return this;
    }

    public IPreparePipelineRunContext WithPlan(PreparePlan plan)
    {
        Plan = plan;
        return this;
    }

    public Task<IResult<IPreparePipelineRunResult>> Success()
    {
        IPreparePipelineRunResult result = resultBuilder
            .InitNew()
            .WithInventory(Inventory)
            .WithClassification(Classification)
            .WithPlan(Plan)
            .Build();

        return Task.FromResult(IResult.Success(result));
    }

    public Task<IResult<IPreparePipelineRunResult>> Failure(Exception ex)
    {
        IPreparePipelineRunResult result = BuildResult();
        return Task.FromResult(IResult.Failure(result, ex.Message, ex));
    }

    public Task<IResult<IPreparePipelineRunResult>> Failure(string message)
    {
        IPreparePipelineRunResult result = BuildResult();
        return Task.FromResult(IResult.Failure(result, message));
    }

    public Task<IResult<IPreparePipelineRunResult>> Failure(string message, Exception ex)
    {
        IPreparePipelineRunResult result = BuildResult();
        return Task.FromResult(IResult.Failure(result, message, ex));
    }

    private IPreparePipelineRunResult BuildResult()
    {
        return resultBuilder
            .InitNew()
            .WithInventory(Inventory)
            .WithClassification(Classification)
            .WithPlan(Plan)
            .Build();
    }
}
