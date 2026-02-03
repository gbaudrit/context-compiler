using ContextCompiler.Abstractions.Rendering;

namespace ContextCompiler.Plugins.BuiltIn.Templates.Scriban.Extensions
{
    internal sealed class Renderable : IRenderable
    {
        public required object Subject { get; init; }
    }
}
