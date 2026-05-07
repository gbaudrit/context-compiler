using System.Globalization;
using System.Text;

using ContextCompiler.Abstractions.Pipelines.Events;

namespace ContextCompiler.Reports.Modules.Pipelines.Mermaid;

internal sealed class PipelineEventCollector :
    IPipelineEventHandler<PhaseStarted>,
    IPipelineEventHandler<PhaseCompleted>,
    IPipelineEventHandler<PhaseFailed>
{
    private readonly List<IPipelineEvent> _events = [];
    private readonly Lock _lock = new();

    public ValueTask HandleAsync(PhaseStarted e, CancellationToken cancellationToken)
    {
        lock (_lock)
        {
            _events.Add(e);
        }
        return ValueTask.CompletedTask;
    }

    public ValueTask HandleAsync(PhaseCompleted e, CancellationToken cancellationToken)
    {
        lock (_lock)
        {
            _events.Add(e);
        }
        return ValueTask.CompletedTask;
    }

    public ValueTask HandleAsync(PhaseFailed e, CancellationToken cancellationToken)
    {
        lock (_lock)
        {
            _events.Add(e);
        }
        return ValueTask.CompletedTask;
    }

    public IReadOnlyList<IPipelineEvent> GetEvents()
    {
        lock (_lock)
        {
            return _events.ToList().AsReadOnly();
        }
    }

    public void Clear()
    {
        lock (_lock)
        {
            _events.Clear();
        }
    }

    public string GenerateMermaidDiagram()
    {
        lock (_lock)
        {
            StringBuilder sb = new();
            _ = sb.AppendLine("graph LR");

            Dictionary<string, List<IPipelineEvent>> eventsByPipeline = _events
                .GroupBy(e => e.PipelineId)
                .ToDictionary(g => g.Key, g => g.OrderBy(e => e.Timestamp).ToList());

            foreach (KeyValuePair<string, List<IPipelineEvent>> kvp in eventsByPipeline)
            {
                string pipelineId = SanitizeId(kvp.Key);
                List<IPipelineEvent> events = kvp.Value;

                _ = sb.AppendLine(CultureInfo.InvariantCulture, $"    subgraph {pipelineId}[{kvp.Key}]");

                string? previousPhaseId = null;

                foreach (IPipelineEvent evt in events)
                {
                    string phaseId = SanitizeId(evt.PhaseId);
                    string nodeId = $"{pipelineId}_{phaseId}";

                    if (evt is PhaseStarted started)
                    {
                        _ = sb.AppendLine(CultureInfo.InvariantCulture, $"        {nodeId}[{evt.PhaseId}<br/>Module: {started.ModuleId}]");
                        _ = sb.AppendLine(CultureInfo.InvariantCulture, $"        style {nodeId} fill:#e1f5fe,stroke:#01579b");
                    }
                    else if (evt is PhaseCompleted completed)
                    {
                        _ = sb.AppendLine(CultureInfo.InvariantCulture, $"        {nodeId}[{evt.PhaseId}<br/>Module: {completed.ModuleId}<br/>{completed.Duration.TotalMilliseconds:F0}ms]");
                        _ = sb.AppendLine(CultureInfo.InvariantCulture, $"        style {nodeId} fill:#c8e6c9,stroke:#2e7d32");
                    }
                    else if (evt is PhaseFailed failed)
                    {
                        _ = sb.AppendLine(CultureInfo.InvariantCulture, $"        {nodeId}[{evt.PhaseId}<br/>Module: {failed.ModuleId}<br/>FAILED]");
                        _ = sb.AppendLine(CultureInfo.InvariantCulture, $"        style {nodeId} fill:#ffcdd2,stroke:#c62828");
                    }

                    if (previousPhaseId != null)
                    {
                        string prevNodeId = $"{pipelineId}_{previousPhaseId}";
                        _ = sb.AppendLine(CultureInfo.InvariantCulture, $"        {prevNodeId} --> {nodeId}");
                    }

                    previousPhaseId = phaseId;
                }

                _ = sb.AppendLine("    end");
            }

            return sb.ToString();
        }
    }

    private static string SanitizeId(string id)
    {
        return id.Replace("-", "_")
                 .Replace(".", "_")
                 .Replace(" ", "_")
                 .Replace("/", "_");
    }
}
