using ContextCompiler.Modules.Abstractions.Prompts;

namespace ContextCompiler.Modules.BuiltIn.Templates.Scriban
{
    internal sealed class ScribanRenderedPromptResult : IRenderedPromptModule
    {
        public required string Filename { get; init; }

        public required string RenderedText { get; init; }

    }
}
