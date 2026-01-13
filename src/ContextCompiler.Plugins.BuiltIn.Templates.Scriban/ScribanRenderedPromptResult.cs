using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Plugins.Prompts;

namespace ContextCompiler.Plugins.BuiltIn.Templates.Scriban
{
    internal sealed class ScribanRenderedPromptResult : IRenderedPromptResult
    {
        public required string Filename { get; init; }

        public required string RenderedText { get; init; }   

    }
}
