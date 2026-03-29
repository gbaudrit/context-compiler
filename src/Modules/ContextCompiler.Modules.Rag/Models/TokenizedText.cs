namespace ContextCompiler.Modules.Rag.Models;

internal sealed record TokenizedText
{

    public required ReadOnlyMemory<long> InputIds { get; init; }
    public required ReadOnlyMemory<long> AttentionMask { get; init; }
    public required ReadOnlyMemory<long> TokenTypeIds { get; init; }

}
