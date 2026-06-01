using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition
{
    public interface IPromptComposerContext
    {

        IPrompt Prompt { get; }

        IOutput Output { get; }

    }
}
