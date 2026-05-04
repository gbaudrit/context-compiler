using ContextCompiler.Abstractions.Rendering;

namespace ContextCompiler.Prompting.Modules.Templates.Scriban.Extensions
{
    internal sealed class Renderable : IRenderable
    {
        public required object Subject { get; init; }
    }
}
