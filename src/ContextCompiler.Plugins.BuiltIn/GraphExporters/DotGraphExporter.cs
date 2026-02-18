using System.Globalization;
using System.Text;

using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Plugins.Abstractions;
using ContextCompiler.Plugins.Abstractions.GlobalPipeline;

namespace ContextCompiler.Plugins.BuiltIn.GraphExporters;

public sealed class DotGraphExporter(IOutput output, IReasoningIr ir) : IOutputArtifactComposerPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.output.evidence.graph.dot", GlobalPipelinePluginKinds.OutputArtifactComposer, priority: 10);

    public async Task Run(CancellationToken cancellationToken)
    {
        IGraph graph = await ir.Graph(cancellationToken);
        StringBuilder sb = new();
        _ = sb.AppendLine("digraph reasoning {");
        foreach (IGraphNode n in graph.Nodes)
        {
            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"  \"{n.Id}\" [label=\"{Escape(n.Label)}\"];");
        }

        foreach (IGraphEdge e in graph.Edges)
        {
            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"  \"{e.FromId}\" -> \"{e.ToId}\" [label=\"{Escape(e.Kind)}\"];");
        }

        _ = sb.AppendLine("}");

        output.AddArtifact(builder =>
        {
            return builder.WithFileName("reasoning.graph.dot")
                          .WithContent(sb.ToString());
        });
    }

    private static string Escape(string s)
    {
        return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }
}
