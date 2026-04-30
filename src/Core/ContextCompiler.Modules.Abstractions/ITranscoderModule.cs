using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Modules.Abstractions;

public sealed record TranscodedFragment(
    string Locator,
    string Content
) : ITranscodedFragment
{
    public IReadOnlyList<ITag> Tags { get; init; } = [];
};
