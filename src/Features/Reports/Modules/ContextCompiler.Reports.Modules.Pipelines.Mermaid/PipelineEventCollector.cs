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

    public string GenerateMermaidDiagram(DiagramDetailLevel detailLevel = DiagramDetailLevel.Detailed)
    {
        lock (_lock)
        {
            return detailLevel == DiagramDetailLevel.Detailed
                ? GenerateDetailedDiagram()
                : GenerateCondensedDiagram();
        }
    }

    private string GenerateDetailedDiagram()
    {
        StringBuilder sb = new();
        _ = sb.AppendLine("graph LR");

        Dictionary<string, List<IPipelineEvent>> eventsByPipeline = _events
            .GroupBy(e => e.RunContext.Pipeline.Id)
            .ToDictionary(g => g.Key, g => g.OrderBy(e => e.Timestamp).ToList());

        foreach (KeyValuePair<string, List<IPipelineEvent>> pipelineKvp in eventsByPipeline)
        {
            string pipelineId = SanitizeId(pipelineKvp.Key);
            List<IPipelineEvent> events = pipelineKvp.Value;

            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"    subgraph {pipelineId}[\"{pipelineKvp.Key}\"]");

            // Group events by phase to create subgraphs
            Dictionary<string, List<IPipelineEvent>> eventsByPhase = events
                .GroupBy(e => e.PhaseId)
                .ToDictionary(g => g.Key, g => g.OrderBy(e => e.Timestamp).ToList());

            string? previousPhaseId = null;

            foreach (KeyValuePair<string, List<IPipelineEvent>> phaseKvp in eventsByPhase)
            {
                string phaseId = SanitizeId(phaseKvp.Key);
                List<IPipelineEvent> phaseEvents = phaseKvp.Value;

                _ = sb.AppendLine(CultureInfo.InvariantCulture, $"        subgraph {pipelineId}_{phaseId}[\"{phaseKvp.Key}\"]");

                string? previousEventNodeId = null;

                foreach (IPipelineEvent evt in phaseEvents)
                {
                    string itemInfo = !string.IsNullOrEmpty(evt.ItemId) ? $"<br/>Item: {evt.ItemId}" : "";
                    string moduleInfo = !string.IsNullOrEmpty(evt.ModuleId) ? $"<br/>Module: {evt.ModuleId}" : "";
                    string eventId = SanitizeId($"{evt.PhaseId}_{evt.ModuleId}_{evt.ItemId}_{evt.Timestamp.Ticks}");
                    string nodeId = $"{pipelineId}_{phaseId}_{eventId}";

                    if (evt is PhaseStarted)
                    {
                        _ = sb.AppendLine(CultureInfo.InvariantCulture,
                            $"            {nodeId}[\"Started{moduleInfo}{itemInfo}<br/>{evt.Timestamp:HH:mm:ss.fff}\"]");
                        _ = sb.AppendLine(CultureInfo.InvariantCulture,
                            $"            style {nodeId} fill:#e1f5fe,stroke:#01579b");
                    }
                    else if (evt is PhaseCompleted completed)
                    {
                        _ = sb.AppendLine(CultureInfo.InvariantCulture,
                            $"            {nodeId}[\"Completed{moduleInfo}{itemInfo}<br/>{completed.Duration.TotalMilliseconds:F0}ms\"]");
                        _ = sb.AppendLine(CultureInfo.InvariantCulture,
                            $"            style {nodeId} fill:#c8e6c9,stroke:#2e7d32");
                    }
                    else if (evt is PhaseFailed failed)
                    {
                        string errorMsg = failed.Exception.Message.Length > 50
                            ? failed.Exception.Message[..50] + "..."
                            : failed.Exception.Message;
                        _ = sb.AppendLine(CultureInfo.InvariantCulture,
                            $"            {nodeId}[\"Failed{moduleInfo}{itemInfo}<br/>{errorMsg}\"]");
                        _ = sb.AppendLine(CultureInfo.InvariantCulture,
                            $"            style {nodeId} fill:#ffcdd2,stroke:#c62828");
                    }

                    if (previousEventNodeId != null)
                    {
                        _ = sb.AppendLine(CultureInfo.InvariantCulture,
                            $"            {previousEventNodeId} --> {nodeId}");
                    }

                    previousEventNodeId = nodeId;
                }

                _ = sb.AppendLine("        end");

                // Link phases together
                if (previousPhaseId != null && previousEventNodeId != null)
                {
                    string? firstEventInPhase = phaseEvents.Count > 0
                        ? $"{pipelineId}_{phaseId}_{SanitizeId($"{phaseEvents[0].PhaseId}_{phaseEvents[0].ModuleId}_{phaseEvents[0].ItemId}_{phaseEvents[0].Timestamp.Ticks}")}"
                        : null;

                    if (firstEventInPhase != null)
                    {
                        _ = sb.AppendLine(CultureInfo.InvariantCulture,
                            $"        {previousEventNodeId} -.-> {firstEventInPhase}");
                    }
                }

                previousPhaseId = phaseId;
            }

            _ = sb.AppendLine("    end");
        }

        return sb.ToString();
    }

    private string GenerateCondensedDiagram()
    {
        StringBuilder sb = new();
        _ = sb.AppendLine("graph LR");

        Dictionary<string, List<IPipelineEvent>> eventsByPipeline = _events
            .GroupBy(e => e.RunContext.Pipeline.Id)
            .ToDictionary(g => g.Key, g => g.OrderBy(e => e.Timestamp).ToList());

        // Group events by phase to reduce diagram size
        foreach (KeyValuePair<string, List<IPipelineEvent>> kvp in eventsByPipeline)
        {
            string pipelineId = SanitizeId(kvp.Key);
            List<IPipelineEvent> events = kvp.Value;

            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"    subgraph {pipelineId}[{kvp.Key}]");

            // Group consecutive events by phase
            Dictionary<string, PhaseGroup> phaseGroups = [];

            foreach (IPipelineEvent evt in events)
            {
                string phaseId = evt.PhaseId;

                if (!phaseGroups.TryGetValue(phaseId, out PhaseGroup? group))
                {
                    group = new PhaseGroup { PhaseId = phaseId };
                    phaseGroups[phaseId] = group;
                }

                if (evt is PhaseStarted started)
                {
                    _ = group.ModuleIds.Add(started.ModuleId);
                    _ = group.ItemIds.Add(started.ItemId);
                    group.HasStarted = true;
                }
                else if (evt is PhaseCompleted completed)
                {
                    _ = group.ModuleIds.Add(completed.ModuleId);
                    _ = group.ItemIds.Add(completed.ItemId);
                    group.TotalDuration += completed.Duration;
                    group.HasCompleted = true;
                }
                else if (evt is PhaseFailed failed)
                {
                    _ = group.ModuleIds.Add(failed.ModuleId);
                    _ = group.ItemIds.Add(failed.ItemId);
                    group.HasFailed = true;
                }
            }

            // Generate nodes for each phase group
            string? previousPhaseId = null;

            foreach (KeyValuePair<string, PhaseGroup> groupKvp in phaseGroups)
            {
                PhaseGroup group = groupKvp.Value;
                string phaseId = SanitizeId(group.PhaseId);
                string nodeId = $"{pipelineId}_{phaseId}";

                int moduleCount = group.ModuleIds.Count;
                int itemCount = group.ItemIds.Count(id => !string.IsNullOrEmpty(id));

                string moduleInfo = moduleCount == 1
                    ? $"Module: {group.ModuleIds.First()}"
                    : $"{moduleCount} modules";

                string itemInfo = itemCount > 0
                    ? $"<br/>{itemCount} items"
                    : "";

                string durationInfo = group.HasCompleted
                    ? $"<br/>{group.TotalDuration.TotalMilliseconds:F0}ms"
                    : "";

                string statusInfo = group.HasFailed ? "<br/>FAILED" : "";

                _ = sb.AppendLine(CultureInfo.InvariantCulture,
                    $"        {nodeId}[{group.PhaseId}<br/>{moduleInfo}{itemInfo}{durationInfo}{statusInfo}]");

                // Apply styling based on status
                if (group.HasFailed)
                {
                    _ = sb.AppendLine(CultureInfo.InvariantCulture,
                        $"        style {nodeId} fill:#ffcdd2,stroke:#c62828");
                }
                else if (group.HasCompleted)
                {
                    _ = sb.AppendLine(CultureInfo.InvariantCulture,
                        $"        style {nodeId} fill:#c8e6c9,stroke:#2e7d32");
                }
                else if (group.HasStarted)
                {
                    _ = sb.AppendLine(CultureInfo.InvariantCulture,
                        $"        style {nodeId} fill:#e1f5fe,stroke:#01579b");
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

    private sealed class PhaseGroup
    {
        public required string PhaseId { get; init; }
        public HashSet<string> ModuleIds { get; } = [];
        public HashSet<string> ItemIds { get; } = [];
        public TimeSpan TotalDuration { get; set; }
        public bool HasStarted { get; set; }
        public bool HasCompleted { get; set; }
        public bool HasFailed { get; set; }
    }

    private static string SanitizeId(string id)
    {
        return id.Replace("-", "_")
                 .Replace(".", "_")
                 .Replace(" ", "_")
                 .Replace("/", "_");
    }
}
