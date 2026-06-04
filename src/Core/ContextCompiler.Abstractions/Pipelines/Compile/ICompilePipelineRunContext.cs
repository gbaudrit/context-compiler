using ContextCompiler.Abstractions.Common;

namespace ContextCompiler.Abstractions.Pipelines.Compile;

public interface ICompilePipelineRunContext : IPipelineRunContext
{
    Task<IResult<ICompilePipelineRunResult>> Success();
    Task<IResult<ICompilePipelineRunResult>> Failure(Exception ex);
    Task<IResult<ICompilePipelineRunResult>> Failure(string message);
    Task<IResult<ICompilePipelineRunResult>> Failure(string message, Exception ex);
}
