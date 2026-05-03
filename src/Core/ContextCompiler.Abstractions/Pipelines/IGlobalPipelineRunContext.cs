using ContextCompiler.Abstractions.Common;

namespace ContextCompiler.Abstractions.Pipelines;

public interface IGlobalPipelineRunContext : IPipelineRunContext
{
    Task<IResult<IGlobalPipelineRunResult>> Success();
    Task<IResult<IGlobalPipelineRunResult>> Failure(Exception ex);
    Task<IResult<IGlobalPipelineRunResult>> Failure(string message);
    Task<IResult<IGlobalPipelineRunResult>> Failure(string message, Exception ex);
}
