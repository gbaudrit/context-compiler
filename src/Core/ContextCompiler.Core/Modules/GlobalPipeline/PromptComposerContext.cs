using ContextCompiler.Abstractions.Output;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Core.Modules.GlobalPipeline
{
    internal sealed class PromptComposerContext : IPromptComposerContext
    {
        public required IPrompt Prompt { get; init; }

        public required IOutput Output { get; init; }
    }
}
