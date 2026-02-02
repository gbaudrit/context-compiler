namespace ContextCompiler.Abstractions.Models;

public sealed record GraphNode(string Id, string Kind, string Label, IReadOnlyDictionary<string, string>? Props = null);
public sealed record GraphEdge(string FromId, string ToId, string Kind, IReadOnlyDictionary<string, string>? Props = null);

public sealed class GraphModel
{
    public List<GraphNode> Nodes { get; } = [];
    public List<GraphEdge> Edges { get; } = [];
}
