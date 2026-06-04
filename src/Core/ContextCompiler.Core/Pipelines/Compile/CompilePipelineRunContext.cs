using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Compile;

namespace ContextCompiler.Core.Pipelines.Compile;

internal sealed class CompilePipelineRunContext(
    IPipeline pipeline,
    string phaseKey,
    ICompilePipelineRunResultBuilder resultBuilder) : ICompilePipelineRunContext
{
    public IPipeline Pipeline { get; } = pipeline;
    public string PhaseKey { get; } = phaseKey;

    public Task<IResult<ICompilePipelineRunResult>> Success()
    {
        ICompilePipelineRunResult result = resultBuilder
            .InitNew()
            .Build();

        return Task.FromResult(IResult.Success(result));
    }

    public Task<IResult<ICompilePipelineRunResult>> Failure(Exception ex)
    {
        ICompilePipelineRunResult result = resultBuilder
            .InitNew()
            .Build();

        return Task.FromResult(IResult.Failure(result, ex.Message, ex));
    }

    public Task<IResult<ICompilePipelineRunResult>> Failure(string message)
    {
        ICompilePipelineRunResult result = resultBuilder
            .InitNew()
            .Build();

        return Task.FromResult(IResult.Failure(result, message));
    }

    public Task<IResult<ICompilePipelineRunResult>> Failure(string message, Exception ex)
    {
        ICompilePipelineRunResult result = resultBuilder
            .InitNew()
            .Build();

        return Task.FromResult(IResult.Failure(result, message, ex));
    }
}
