namespace ContextCompiler.Abstractions.ReasoningIR
{
    public interface IGraph
    {
        public IReadOnlyList<IGraphNode> Nodes { get; }
        public IReadOnlyList<IGraphEdge> Edges { get; }
    }

    public interface IGraphNode
    {
        string Id { get; }
        string Kind { get; }
        string Label { get; }
        IReadOnlyDictionary<string, string>? Props { get; }
    }

    public interface IGraphEdge
    {
        string FromId { get; }
        string ToId { get; }
        string Kind { get; }
        IReadOnlyDictionary<string, string>? Props { get; }
    }
}
