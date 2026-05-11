using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;

namespace ContextCompiler.Prompting.Pipelines.PromptComposition;

internal sealed class PromptComposerRunContextBuilder(
    IPromptComposerRunResultBuilder resultBuilder) : IPromptComposerRunContextBuilder
{
    private IPipeline? _pipeline;
    private IPipelineRunContext? _parent;
    private IPrompt? _prompt;

    public IPromptComposerRunContextBuilder InitNew()
    {
        _pipeline = null;
        _parent = null;
        _prompt = null;
        return this;
    }

    public IPromptComposerRunContextBuilder WithPipeline(IPipeline pipeline)
    {
        _pipeline = pipeline;
        return this;
    }

    public IPromptComposerRunContextBuilder WithParent(IPipelineRunContext parent)
    {
        _parent = parent;
        return this;
    }

    public IPromptComposerRunContextBuilder WithPrompt(IPrompt prompt)
    {
        _prompt = prompt;
        return this;
    }

    public IPromptComposerRunContext Build()
    {
        ArgumentNullException.ThrowIfNull(_pipeline, nameof(_pipeline));
        ArgumentNullException.ThrowIfNull(_parent, nameof(_parent));
        ArgumentNullException.ThrowIfNull(_prompt, nameof(_prompt));

        return new PromptComposerRunContext(_pipeline, _parent, _prompt, resultBuilder);
    }
}
