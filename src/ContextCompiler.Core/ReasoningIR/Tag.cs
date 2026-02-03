using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Core.ReasoningIR
{
    public record Tag(
        string Name,
        string? Value = null
    ) : ITag;
}
