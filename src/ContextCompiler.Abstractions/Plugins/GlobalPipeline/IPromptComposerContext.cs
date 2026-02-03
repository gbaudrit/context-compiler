using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Abstractions.Plugins.GlobalPipeline
{
    public interface IPromptComposerContext
    {

        IPrompt Prompt { get; }

        IOutput Output { get; }

    }
}
