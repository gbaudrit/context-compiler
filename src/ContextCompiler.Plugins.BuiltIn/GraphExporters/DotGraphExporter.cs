using System.Globalization;
using System.Text;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.GraphExporters;

public sealed class DotGraphExporter : IGraphExporterPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.graph.dot", PluginKinds.GraphExporter, priority: 10);
    public string FormatId => "dot";
    public string FileExtension => ".dot";

    public string Export(object graphModel)
    {
        var g = (GraphModel)graphModel;
        var sb = new StringBuilder();
        sb.AppendLine("digraph reasoning {");
        foreach (var n in g.Nodes)
            sb.AppendLine(CultureInfo.InvariantCulture, $"  \"{n.Id}\" [label=\"{Escape(n.Label)}\"];");
        foreach (var e in g.Edges)
            sb.AppendLine(CultureInfo.InvariantCulture, $"  \"{e.FromId}\" -> \"{e.ToId}\" [label=\"{Escape(e.Kind)}\"];");
        sb.AppendLine("}");
        return sb.ToString();
    }

    private static string Escape(string s) => s.Replace("\\", "\\\\").Replace("\"", "\\\"");
}
