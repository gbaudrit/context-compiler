using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;

namespace ContextCompiler.Prompting.Pipelines.PromptComposition;

internal sealed class PromptComposerRunResultBuilder : IPromptComposerRunResultBuilder
{
    public IPromptComposerRunResultBuilder InitNew()
    {
        return this;
    }

    public IPromptComposerRunResult Build()
    {
        return new PromptComposerRunResult();
    }
}
