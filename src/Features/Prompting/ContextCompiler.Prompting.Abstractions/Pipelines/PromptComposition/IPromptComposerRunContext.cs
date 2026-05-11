using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines;

namespace ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;

public interface IPromptComposerRunContext : ISubPipelineRunContext
{
    IPrompt Prompt { get; }

    Task<IResult<IPromptComposerRunResult>> Success();
    Task<IResult<IPromptComposerRunResult>> Failure(Exception ex);
    Task<IResult<IPromptComposerRunResult>> Failure(string message);
    Task<IResult<IPromptComposerRunResult>> Failure(string message, Exception ex);
}
