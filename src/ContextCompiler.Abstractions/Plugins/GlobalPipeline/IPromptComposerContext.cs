using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Abstractions.Plugins.GlobalPipeline
{
    public interface IPromptComposerContext
    {

        public IPrompt Prompt { get; }

        public IOutput Output { get; }

    }
}
