using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines;

namespace ContextCompiler.Core.Pipelines;

internal sealed class GlobalPipelineRunContext(
    IPipeline pipeline,
    IGlobalPipelineRunResultBuilder resultBuilder) : IGlobalPipelineRunContext
{
    public IPipeline Pipeline { get; } = pipeline;

    public Task<IResult<IGlobalPipelineRunResult>> Success()
    {
        IGlobalPipelineRunResult result = resultBuilder
            .InitNew()
            .Build();

        return Task.FromResult(IResult.Success(result));
    }

    public Task<IResult<IGlobalPipelineRunResult>> Failure(Exception ex)
    {
        IGlobalPipelineRunResult result = resultBuilder
            .InitNew()
            .Build();

        return Task.FromResult(IResult.Failure(result, ex.Message, ex));
    }

    public Task<IResult<IGlobalPipelineRunResult>> Failure(string message)
    {
        IGlobalPipelineRunResult result = resultBuilder
            .InitNew()
            .Build();

        return Task.FromResult(IResult.Failure(result, message));
    }

    public Task<IResult<IGlobalPipelineRunResult>> Failure(string message, Exception ex)
    {
        IGlobalPipelineRunResult result = resultBuilder
            .InitNew()
            .Build();

        return Task.FromResult(IResult.Failure(result, message, ex));
    }
}
