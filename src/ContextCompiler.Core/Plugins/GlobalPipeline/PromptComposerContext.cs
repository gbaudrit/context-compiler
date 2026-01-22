using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;

namespace ContextCompiler.Core.Plugins.GlobalPipeline
{
    internal sealed class PromptComposerContext : IPromptComposerContext
    {
        public required IPrompt Prompt { get; init; }

        public required IOutput Output { get; init; }
    }
}
