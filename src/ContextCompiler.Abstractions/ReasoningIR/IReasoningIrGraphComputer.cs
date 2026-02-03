namespace ContextCompiler.Abstractions.ReasoningIR
{
    public interface IReasoningIrGraphComputer
    {

        ValueTask<IGraph> Compute(IReasoningIr inputGraph, CancellationToken ct);

    }
}
