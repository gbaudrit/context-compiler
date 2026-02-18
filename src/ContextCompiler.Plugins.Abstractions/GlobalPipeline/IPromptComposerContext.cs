using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Plugins.Abstractions.GlobalPipeline
{
    public interface IPromptComposerContext
    {

        IPrompt Prompt { get; }

        IOutput Output { get; }

    }
}
