using System.Globalization;
using System.Text;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Evidence.Modules.Graph.Dot;

public sealed class DotGraphExporterModule(IOutput output, IReasoningIr ir) : IOutputArtifactComposerModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("evidence.graph.dot", GlobalPipelineModuleKinds.ReportComposition, priority: 10);

    public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
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
                          .WithContent(sb.ToString())
                          .WithGeneratedBy(GetType());
        });

        return await context.Success();
    }

    private static string Escape(string s)
    {
        return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }
}
