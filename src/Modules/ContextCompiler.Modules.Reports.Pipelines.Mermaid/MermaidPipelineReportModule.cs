using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Events;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Reports.Pipelines.Mermaid;

internal sealed class MermaidPipelineReportModule(
    PipelineEventCollector eventCollector,
    IOutput output,
    ILogger<MermaidPipelineReportModule> logger) : IGlobalPipelineModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta(
        "reports.pipelines.mermaid",
        GlobalPipelineModuleKinds.ReportComposition,
        priority: 900);

    public Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        IReadOnlyList<IPipelineEvent> events = eventCollector.GetEvents();

        if (events.Count == 0)
        {
            logger.LogInformation("No pipeline events collected, skipping Mermaid report generation");
            return context.Success();
        }

        logger.LogInformation("Generating Mermaid pipeline report from {EventCount} events", events.Count);

        string mermaidDiagram = eventCollector.GenerateMermaidDiagram();
        string htmlContent = MermaidHtmlGenerator.GenerateHtml(
            mermaidDiagram,
            "Pipeline Execution Report");


        output.AddArtifact(builder =>
        {
            return builder.WithFileName("pipeline-report.html")
                          .WithContent(htmlContent)
                          .WithGeneratedBy(GetType());
        });

        logger.LogInformation("Mermaid pipeline report generated");

        return context.Success();
    }
}
