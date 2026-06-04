using System.Globalization;
using System.Text;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.CompilePipeline;

namespace ContextCompiler.Evidence.Modules.Graph.Dot;

public sealed class DotGraphExporterModule(IOutput output, ICompiledContext compiledContext) : IOutputArtifactComposerModule
{
    public ModuleMetadata Metadata => ICompilePipelineModule.Meta("evidence.graph.dot", CompilePipelineModuleKinds.ReportComposition, priority: 10);

    public async Task<IResult<ICompilePipelineRunResult>> Run(ICompilePipelineRunContext context, CancellationToken cancellationToken)
    {
        IGraph graph = await compiledContext.Graph(cancellationToken);
        StringBuilder sb = new();
        _ = sb.AppendLine("digraph evidence {");
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
            return builder.WithFileName("evidence.graph.dot")
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
