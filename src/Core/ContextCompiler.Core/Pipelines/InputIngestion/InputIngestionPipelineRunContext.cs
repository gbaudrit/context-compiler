using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Core.Pipelines.InputIngestion;

internal sealed class InputIngestionPipelineRunContext(
    IPipeline pipeline,
    IInputItemContext InputItemContext,
    IInputItemContextPatchBuilder patchContext,
    IInputIngestionPipelineRunResultBuilder resultBuilder) : IInputIngestionPipelineRunContext
{
    public IPipeline Pipeline { get; } = pipeline;
    public IInputItemContext InputItem { get; } = InputItemContext;
    public IInputItemContextPatchBuilder Patch { get; } = patchContext;

    public Task<IResult<IInputIngestionPipelineRunResult>> Success()
    {
        IInputIngestionPipelineRunResult result = resultBuilder
            .InitNew()
            .WithPatch(Patch.Build())
            .Build();

        return Task.FromResult(IResult.Success(result));
    }

    public Task<IResult<IInputIngestionPipelineRunResult>> NoChanges()
    {
        IInputIngestionPipelineRunResult result = resultBuilder
            .InitNew()
            .WithPatch(Patch.Build())
            .Build();

        return Task.FromResult(IResult.Success(result));
    }

    public Task<IResult<IInputIngestionPipelineRunResult>> NothingToDo()
    {
        IInputIngestionPipelineRunResult result = resultBuilder
            .InitNew()
            .WithPatch(Patch.Build())
            .Build();

        return Task.FromResult(IResult.Success(result));
    }

    public Task<IResult<IInputIngestionPipelineRunResult>> Failure(Exception ex)
    {
        IInputIngestionPipelineRunResult result = resultBuilder
            .InitNew()
            .WithPatch(Patch.Build())
            .Build();

        return Task.FromResult(IResult.Failure(result, ex.Message, ex));
    }

    public Task<IResult<IInputIngestionPipelineRunResult>> Failure(string message)
    {
        IInputIngestionPipelineRunResult result = resultBuilder
            .InitNew()
            .WithPatch(Patch.Build())
            .Build();

        return Task.FromResult(IResult.Failure(result, message));
    }

    public Task<IResult<IInputIngestionPipelineRunResult>> Failure(string message, Exception ex)
    {
        IInputIngestionPipelineRunResult result = resultBuilder
            .InitNew()
            .WithPatch(Patch.Build())
            .Build();

        return Task.FromResult(IResult.Failure(result, message, ex));
    }

    IInputIngestionPipelineRunContext IInputIngestionPipelineRunContext.Patch(Func<IInputItemContextPatchBuilder, IInputItemContextPatchBuilder> b)
    {
        _ = b(Patch);
        return this;
    }

    IInputIngestionPipelineRunContext IInputIngestionPipelineRunContext.Patch(Action<IInputItemContextPatchBuilder> b)
    {
        b(Patch);
        return this;
    }
}
