namespace ContextCompiler.Abstractions.ReasoningIR;

public interface IReasoningIr
{
    IReadOnlyList<IFragment> Fragments { get; }

    void Add(IFragment fragment);
    ValueTask<IGraph> Graph(CancellationToken ct);
}
