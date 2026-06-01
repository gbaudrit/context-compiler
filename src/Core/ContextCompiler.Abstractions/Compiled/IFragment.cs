using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Compiled;

public interface IFragment
{
    string Content { get; init; }
    IEvidence Evidence { get; init; }
    ISourceRef Source { get; init; }
    IReadOnlyList<ITag> Tags { get; init; }
}
