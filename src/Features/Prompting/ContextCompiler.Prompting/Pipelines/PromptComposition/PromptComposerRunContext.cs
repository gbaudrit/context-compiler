using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;

namespace ContextCompiler.Prompting.Pipelines.PromptComposition;

internal sealed class PromptComposerRunContext(
    IPipeline pipeline,
    string phaseKey,
    IPipelineRunContext parent,
    IPrompt prompt,
    IPromptComposerRunResultBuilder resultBuilder) : IPromptComposerRunContext
{
    public IPipelineRunContext Parent => parent;
    public IPipeline Pipeline { get; } = pipeline;
    public string PhaseKey { get; } = phaseKey;
    public IPrompt Prompt { get; } = prompt;

    public Task<IResult<IPromptComposerRunResult>> Success()
    {
        IPromptComposerRunResult result = resultBuilder
            .InitNew()
            .Build();

        return Task.FromResult(IResult.Success(result));
    }

    public Task<IResult<IPromptComposerRunResult>> Failure(Exception ex)
    {
        IPromptComposerRunResult result = resultBuilder
            .InitNew()
            .Build();

        return Task.FromResult(IResult.Failure(result, ex.Message, ex));
    }

    public Task<IResult<IPromptComposerRunResult>> Failure(string message)
    {
        IPromptComposerRunResult result = resultBuilder
            .InitNew()
            .Build();

        return Task.FromResult(IResult.Failure(result, message));
    }

    public Task<IResult<IPromptComposerRunResult>> Failure(string message, Exception ex)
    {
        IPromptComposerRunResult result = resultBuilder
            .InitNew()
            .Build();

        return Task.FromResult(IResult.Failure(result, message, ex));
    }
}
