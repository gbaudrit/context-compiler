using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Core.ReasoningIR;



public sealed class Fragment() : IFragment
{
    public required IEvidence Evidence { get; init; }
    public required string Content { get; init; }
    public required ISourceRef Source { get; init; }
    public IReadOnlyList<ITag> Tags { get; init; } = [];
}

public sealed class ReasoningIr(IReasoningIrGraphComputer reasoningIrGraphComputer) : IReasoningIr
{
    private readonly List<IFragment> _fragments = [];
    public IReadOnlyList<IFragment> Fragments => _fragments;

    public void Add(IFragment fragment)
    {
        _fragments.Add(fragment);
    }

    public ValueTask<IGraph> Graph(CancellationToken ct)
    {
        return reasoningIrGraphComputer.Compute(this, ct);
    }
}
