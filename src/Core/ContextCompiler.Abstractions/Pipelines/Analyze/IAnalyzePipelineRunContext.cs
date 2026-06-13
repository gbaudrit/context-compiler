using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models.Analyze;
using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Abstractions.Pipelines.Analyze;

public interface IAnalyzePipelineRunContext : IPipelineRunContext
{
    AnalyzeRequest Request { get; }

    ProjectInventory? Inventory { get; }

    ProjectClassification? Classification { get; }

    AnalyzePlan? Plan { get; }

    IAnalyzePipelineRunContext WithInventory(ProjectInventory inventory);

    IAnalyzePipelineRunContext WithClassification(ProjectClassification classification);

    IAnalyzePipelineRunContext WithPlan(AnalyzePlan plan);

    Task<IResult<IAnalyzePipelineRunResult>> Success();
    Task<IResult<IAnalyzePipelineRunResult>> Failure(Exception ex);
    Task<IResult<IAnalyzePipelineRunResult>> Failure(string message);
    Task<IResult<IAnalyzePipelineRunResult>> Failure(string message, Exception ex);
}
