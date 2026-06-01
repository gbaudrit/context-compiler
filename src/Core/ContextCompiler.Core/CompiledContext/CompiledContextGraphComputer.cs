using ContextCompiler.Abstractions.Compiled;

namespace ContextCompiler.Core.CompiledContext
{
    internal sealed class CompiledContextGraphComputer() : ICompiledContextGraphComputer
    {
        public ValueTask<IGraph> Compute(ICompiledContext ir, CancellationToken ct)
        {
            List<IGraphNode> nodes = [];
            List<IGraphEdge> edges = [];
            foreach (IFragment frag in ir.Fragments)
            {
                nodes.Add(new GraphNode(frag.Evidence.EvidenceKey, "Evidence", frag.Evidence.EvidenceKey, new Dictionary<string, string>
                {
                    ["source"] = frag.Source.Uri.AbsolutePath,
                    ["locator"] = frag.Source.Locator ?? ""
                }));
                string srcId = frag.Source.Id;
                if (!nodes.Any(n => n.Id == srcId))
                {
                    nodes.Add(new GraphNode(srcId, "Source", Path.GetFileName(frag.Source.Uri.AbsolutePath), new Dictionary<string, string> { { "path", frag.Source.Uri.AbsolutePath } }));
                }

                edges.Add(new GraphEdge(frag.Evidence.EvidenceKey, srcId, "DerivedFrom"));
            }
            return ValueTask.FromResult<IGraph>(new GraphModel { Nodes = nodes, Edges = edges });
        }

        public sealed record GraphNode(string Id, string Kind, string Label, IReadOnlyDictionary<string, string>? Props = null) : IGraphNode;
        public sealed record GraphEdge(string FromId, string ToId, string Kind, IReadOnlyDictionary<string, string>? Props = null) : IGraphEdge;

        public sealed class GraphModel : IGraph
        {
            public required IReadOnlyList<IGraphNode> Nodes { get; init; } = [];
            public required IReadOnlyList<IGraphEdge> Edges { get; init; } = [];
        }
    }
}
