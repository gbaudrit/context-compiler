namespace ContextCompiler.Abstractions.Compiled
{
    public interface ICompiledContextGraphComputer
    {

        ValueTask<IGraph> Compute(ICompiledContext inputGraph, CancellationToken ct);

    }
}
