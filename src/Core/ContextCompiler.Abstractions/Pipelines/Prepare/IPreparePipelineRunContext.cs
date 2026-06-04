using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Abstractions.Pipelines.Prepare;

public interface IPreparePipelineRunContext : IPipelineRunContext
{
    PrepareRequest Request { get; }

    ProjectInventory? Inventory { get; }

    ProjectClassification? Classification { get; }

    PreparePlan? Plan { get; }

    IPreparePipelineRunContext WithInventory(ProjectInventory inventory);

    IPreparePipelineRunContext WithClassification(ProjectClassification classification);

    IPreparePipelineRunContext WithPlan(PreparePlan plan);

    Task<IResult<IPreparePipelineRunResult>> Success();
    Task<IResult<IPreparePipelineRunResult>> Failure(Exception ex);
    Task<IResult<IPreparePipelineRunResult>> Failure(string message);
    Task<IResult<IPreparePipelineRunResult>> Failure(string message, Exception ex);
}
