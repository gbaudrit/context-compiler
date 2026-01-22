using System.Globalization;
using System.Text;

using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Plugins.BuiltIn.GraphExporters;

public sealed class DotGraphExporter(IOutput output, IReasoningIr ir) : IOutputArtifactComposerPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.output.evidence.graph.dot", GlobalPipelinePluginKinds.OutputArtifactComposer, priority: 10);

    public async Task Run(CancellationToken cancellationToken)
    {
        IGraph graph = await ir.Graph(cancellationToken);
        var sb = new StringBuilder();
        sb.AppendLine("digraph reasoning {");
        foreach (var n in graph.Nodes)
            sb.AppendLine(CultureInfo.InvariantCulture, $"  \"{n.Id}\" [label=\"{Escape(n.Label)}\"];");
        foreach (var e in graph.Edges)
            sb.AppendLine(CultureInfo.InvariantCulture, $"  \"{e.FromId}\" -> \"{e.ToId}\" [label=\"{Escape(e.Kind)}\"];");
        sb.AppendLine("}");

        output.AddArtifact(builder =>
        {
            return builder.WithFileName("reasoning.graph.dot")
                          .WithContent(sb.ToString());
        });
    }

    private static string Escape(string s) => s.Replace("\\", "\\\\").Replace("\"", "\\\"");

    
}
