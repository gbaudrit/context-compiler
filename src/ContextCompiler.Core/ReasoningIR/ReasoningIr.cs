using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Core.ReasoningIR;



public sealed class Fragment() : IFragment
{
    public required IEvidence Evidence { get; init; }
    public required string Content { get; init; }
    public required ISourceRef Source { get; init; }
    public IReadOnlyList<ITag> Tags { get; init; } = new List<ITag>();
}

public sealed class ReasoningIr(IReasoningIrGraphComputer reasoningIrGraphComputer) : IReasoningIr
{
    private readonly List<IFragment> _fragments = new();
    public IReadOnlyList<IFragment> Fragments => _fragments;

    public void Add(IFragment fragment) => _fragments.Add(fragment);

    public ValueTask<IGraph> Graph(CancellationToken ct) => reasoningIrGraphComputer.Compute(this, ct);
}
