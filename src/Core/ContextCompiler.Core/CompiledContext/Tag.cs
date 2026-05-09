using ContextCompiler.Abstractions.Compiled;

namespace ContextCompiler.Core.CompiledContext
{
    public record Tag(
        string Name,
        string? Value = null
    ) : ITag;
}
