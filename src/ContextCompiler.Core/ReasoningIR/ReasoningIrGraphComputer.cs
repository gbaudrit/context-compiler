using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Core.ReasoningIR
{
    internal sealed class ReasoningIrGraphComputer(IHasher hasher) : IReasoningIrGraphComputer
    {
        public ValueTask<IGraph> Compute(IReasoningIr ir, CancellationToken ct)
        {
            List<IGraphNode> nodes = new();
            List<IGraphEdge> edges = new();
            foreach (var frag in ir.Fragments)
            {
                nodes.Add(new GraphNode(frag.Evidence.EvidenceKey, "Evidence", frag.Evidence.EvidenceKey, new Dictionary<string, string>
                {
                    ["source"] = frag.Source.Path,
                    ["locator"] = frag.Source.Locator ?? ""
                }));
                var srcId = "S-" + hasher.Sha256Hex(frag.Source.Path)[..10];
                if (!nodes.Any(n => n.Id == srcId))
                    nodes.Add(new GraphNode(srcId, "Source", Path.GetFileName(frag.Source.Path), new Dictionary<string, string> { { "path", frag.Source.Path } }));
                edges.Add(new GraphEdge(frag.Evidence.EvidenceKey, srcId, "DerivedFrom"));
            }
            return ValueTask.FromResult<IGraph>(new GraphModel { Nodes = nodes, Edges = edges });
        }

        public sealed record GraphNode(string Id, string Kind, string Label, IReadOnlyDictionary<string, string>? Props = null) : IGraphNode;
        public sealed record GraphEdge(string FromId, string ToId, string Kind, IReadOnlyDictionary<string, string>? Props = null) : IGraphEdge;

        public sealed class GraphModel : IGraph
        {
            public required IReadOnlyList<IGraphNode> Nodes { get; init; } = new List<IGraphNode>();
            public required IReadOnlyList<IGraphEdge> Edges { get; init; } = new List<IGraphEdge>();
        }
    }
}
