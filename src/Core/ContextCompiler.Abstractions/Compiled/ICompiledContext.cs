namespace ContextCompiler.Abstractions.Compiled;

public interface ICompiledContext
{
    IReadOnlyList<IFragment> Fragments { get; }

    void Add(IFragment fragment);
    ValueTask<IGraph> Graph(CancellationToken ct);
}
