using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Modules.Abstractions.GlobalPipeline
{
    public interface IPromptComposerContext
    {

        IPrompt Prompt { get; }

        IOutput Output { get; }

    }
}
