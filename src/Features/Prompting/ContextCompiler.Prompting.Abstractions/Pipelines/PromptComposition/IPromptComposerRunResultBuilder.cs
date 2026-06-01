namespace ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;

public interface IPromptComposerRunResultBuilder
{
    IPromptComposerRunResult Build();
    IPromptComposerRunResultBuilder InitNew();
}
