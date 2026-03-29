using ContextCompiler.Abstractions.Rendering;

namespace ContextCompiler.Modules.Prompt.Templates.Scriban.Extensions
{
    internal sealed class Renderable : IRenderable
    {
        public required object Subject { get; init; }
    }
}
