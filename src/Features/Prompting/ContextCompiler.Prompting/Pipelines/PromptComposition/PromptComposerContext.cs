using ContextCompiler.Abstractions.Output;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;

namespace ContextCompiler.Prompting.Pipelines.PromptComposition
{
    internal sealed class PromptComposerContext : IPromptComposerContext
    {
        public required IPrompt Prompt { get; init; }

        public required IOutput Output { get; init; }
    }
}
