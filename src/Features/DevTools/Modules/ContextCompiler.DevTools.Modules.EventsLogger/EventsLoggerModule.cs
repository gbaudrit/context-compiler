using System.Globalization;
using System.Text;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Events;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.DevTools.Modules.EventsLogger;

internal sealed class EventsLoggerModule(
    PipelineEventsCollector eventCollector,
    IOutput output,
    ILogger<EventsLoggerModule> logger) : IGlobalPipelineModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta(
        "devtools.events.logger",
        GlobalPipelineModuleKinds.ReportComposition,
        priority: 1000);

    public Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        IReadOnlyList<IPipelineEvent> events = eventCollector.GetEvents();

        if (events.Count == 0)
        {
            logger.LogInformation("No pipeline events collected, skipping events log generation");
            return context.Success();
        }

        logger.LogInformation("Generating pipeline events log from {EventCount} events", events.Count);

        string logContent = GenerateEventsLog(events);

        output.AddArtifact(builder =>
        {
            return builder.WithFileName("pipeline-events.log")
                          .WithContent(logContent)
                          .WithGeneratedBy(GetType());
        });

        logger.LogInformation("Pipeline events log generated successfully");

        return context.Success();
    }

    private static string GenerateEventsLog(IReadOnlyList<IPipelineEvent> events)
    {
        StringBuilder sb = new();

        _ = sb.AppendLine("=".PadRight(80, '='))
        .AppendLine("PIPELINE EVENTS LOG")
        .AppendLine(CultureInfo.InvariantCulture, $"Generated: {DateTimeOffset.UtcNow:yyyy-MM-dd HH:mm:ss.fff} UTC")
        .AppendLine(CultureInfo.InvariantCulture, $"Total Events: {events.Count}")
        .AppendLine("=".PadRight(80, '='))
        .AppendLine();

        foreach (IPipelineEvent evt in events)
        {
            _ = sb.AppendLine("-".PadRight(80, '-'))
            .AppendLine(CultureInfo.InvariantCulture, $"Timestamp: {evt.Timestamp:yyyy-MM-dd HH:mm:ss.fff}")
            .AppendLine(CultureInfo.InvariantCulture, $"Event Type: {evt.Name}")
            .AppendLine(CultureInfo.InvariantCulture, $"Pipeline: {evt.RunContext.Pipeline.Id}")
            .AppendLine(CultureInfo.InvariantCulture, $"Current Phase Key: {evt.RunContext.PhaseKey}");

            if (evt.RunContext is ISubPipelineRunContext subContext)
            {
                _ = sb.AppendLine(CultureInfo.InvariantCulture, $"Parent Pipeline: {subContext.Parent.Pipeline.Id}")
                .AppendLine(CultureInfo.InvariantCulture, $"Parent Current Phase Key: {subContext.Parent.PhaseKey}");
            }

            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"Phase: {evt.PhaseId}")
            .AppendLine(CultureInfo.InvariantCulture, $"Module: {evt.ModuleId}")
            .AppendLine(CultureInfo.InvariantCulture, $"Item: {evt.ItemId}");

            switch (evt)
            {
                case PhaseCompleted completed:
                    _ = sb.AppendLine(CultureInfo.InvariantCulture, $"Duration: {completed.Duration.TotalMilliseconds:F2} ms");
                    break;

                case PhaseFailed failed:
                    _ = sb.AppendLine(CultureInfo.InvariantCulture, $"Error: {failed.Exception.GetType().Name}")
                    .AppendLine(CultureInfo.InvariantCulture, $"Message: {failed.Exception.Message}");
                    if (failed.Exception.StackTrace is not null)
                    {
                        _ = sb.AppendLine("Stack Trace:")
                        .AppendLine(failed.Exception.StackTrace);
                    }
                    break;
                default:
                    break;
            }

            _ = sb.AppendLine();
        }

        _ = sb.AppendLine("=".PadRight(80, '='))
        .AppendLine("END OF LOG")
        .AppendLine("=".PadRight(80, '='));

        return sb.ToString();
    }
}
