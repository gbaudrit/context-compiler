using ContextCompiler.Modules.Abstractions.Prompts;

namespace ContextCompiler.Prompting.Modules.Templates.Scriban
{
    internal sealed class ScribanRenderedPromptResult : IRenderedPromptModule
    {
        public required string Filename { get; init; }

        public required string RenderedText { get; init; }

    }
}
