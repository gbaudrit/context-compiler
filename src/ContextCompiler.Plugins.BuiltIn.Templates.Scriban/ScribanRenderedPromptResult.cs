using ContextCompiler.Plugins.Abstractions.Prompts;

namespace ContextCompiler.Plugins.BuiltIn.Templates.Scriban
{
    internal sealed class ScribanRenderedPromptResult : IRenderedPromptResult
    {
        public required string Filename { get; init; }

        public required string RenderedText { get; init; }

    }
}
