using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Pipelines.Document;

internal sealed class DocumentPipelineRunContext(
    IPipeline pipeline,
    IDocumentContext documentContext,
    IDocumentContextPatchBuilder patchContext,
    IDocumentPipelineRunResultBuilder resultBuilder) : IDocumentPipelineRunContext
{
    public IPipeline Pipeline { get; } = pipeline;
    public IDocumentContext Document { get; } = documentContext;
    public IDocumentContextPatchBuilder Patch { get; } = patchContext;

    public Task<IResult<IDocumentPipelineRunResult>> Success()
    {
        IDocumentPipelineRunResult result = resultBuilder
            .InitNew()
            .WithPatch(Patch.Build())
            .Build();

        return Task.FromResult(IResult.Success(result));
    }

    public Task<IResult<IDocumentPipelineRunResult>> NoChanges()
    {
        IDocumentPipelineRunResult result = resultBuilder
            .InitNew()
            .WithPatch(Patch.Build())
            .Build();

        return Task.FromResult(IResult.Success(result));
    }

    public Task<IResult<IDocumentPipelineRunResult>> NothingToDo()
    {
        IDocumentPipelineRunResult result = resultBuilder
            .InitNew()
            .WithPatch(Patch.Build())
            .Build();

        return Task.FromResult(IResult.Success(result));
    }

    public Task<IResult<IDocumentPipelineRunResult>> Failure(Exception ex)
    {
        IDocumentPipelineRunResult result = resultBuilder
            .InitNew()
            .WithPatch(Patch.Build())
            .Build();

        return Task.FromResult(IResult.Failure(result, ex.Message, ex));
    }

    public Task<IResult<IDocumentPipelineRunResult>> Failure(string message)
    {
        IDocumentPipelineRunResult result = resultBuilder
            .InitNew()
            .WithPatch(Patch.Build())
            .Build();

        return Task.FromResult(IResult.Failure(result, message));
    }

    public Task<IResult<IDocumentPipelineRunResult>> Failure(string message, Exception ex)
    {
        IDocumentPipelineRunResult result = resultBuilder
            .InitNew()
            .WithPatch(Patch.Build())
            .Build();

        return Task.FromResult(IResult.Failure(result, message, ex));
    }

    IDocumentPipelineRunContext IDocumentPipelineRunContext.Patch(Func<IDocumentContextPatchBuilder, IDocumentContextPatchBuilder> b)
    {
        _ = b(Patch);
        return this;
    }

    IDocumentPipelineRunContext IDocumentPipelineRunContext.Patch(Action<IDocumentContextPatchBuilder> b)
    {
        b(Patch);
        return this;
    }
}
