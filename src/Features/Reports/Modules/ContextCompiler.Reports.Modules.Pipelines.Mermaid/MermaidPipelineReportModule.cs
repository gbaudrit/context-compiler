using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Events;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Reports.Modules.Pipelines.Mermaid;

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

        // Generate interactive view (recommended)
        string interactiveHtml = InteractiveMermaidHtmlGenerator.GenerateHtml(
            events,
            "Pipeline Execution Report - Interactive");

        output.AddArtifact(builder =>
        {
            return builder.WithFileName("pipeline-report-interactive.html")
                          .WithContent(interactiveHtml)
                          .WithGeneratedBy(GetType());
        });

        // Generate detailed view
        string detailedDiagram = eventCollector.GenerateMermaidDiagram(DiagramDetailLevel.Detailed);
        string detailedHtml = MermaidHtmlGenerator.GenerateHtml(
            detailedDiagram,
            "Pipeline Execution Report - Detailed View",
            events.Count);

        output.AddArtifact(builder =>
        {
            return builder.WithFileName("pipeline-report-detailed.html")
                          .WithContent(detailedHtml)
                          .WithGeneratedBy(GetType());
        });

        // Generate condensed view
        string condensedDiagram = eventCollector.GenerateMermaidDiagram(DiagramDetailLevel.Condensed);
        string condensedHtml = MermaidHtmlGenerator.GenerateHtml(
            condensedDiagram,
            "Pipeline Execution Report - Condensed View",
            events.Count);

        output.AddArtifact(builder =>
        {
            return builder.WithFileName("pipeline-report-condensed.html")
                          .WithContent(condensedHtml)
                          .WithGeneratedBy(GetType());
        });

        logger.LogInformation("Mermaid pipeline reports generated (interactive, detailed and condensed views)");

        return context.Success();
    }
}
