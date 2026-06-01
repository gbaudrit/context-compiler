using ContextCompiler.Abstractions.Pipelines;

namespace ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;

public interface IPromptComposerRunContextBuilder
{
    IPromptComposerRunContext Build();
    IPromptComposerRunContextBuilder InitNew();
    IPromptComposerRunContextBuilder WithPipeline(IPipeline pipeline);
    IPromptComposerRunContextBuilder WithParent(IPipelineRunContext parent);
    IPromptComposerRunContextBuilder WithPrompt(IPrompt prompt);
    IPromptComposerRunContextBuilder WithPhaseKey(string phaseKey);
}
