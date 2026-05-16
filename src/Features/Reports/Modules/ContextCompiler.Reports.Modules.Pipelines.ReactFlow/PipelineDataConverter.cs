using System.Text.Json;
using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Events;

namespace ContextCompiler.Reports.Modules.Pipelines.ReactFlow;

/// <summary>
/// Converts pipeline events to a JSON structure optimized for React Flow visualization.
/// </summary>
internal static class PipelineDataConverter
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        WriteIndented = false,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public static string ConvertToJson(IReadOnlyList<IPipelineEvent> events)
    {
        GraphData graphData = BuildGraphData(events);

        return JsonSerializer.Serialize(graphData, _jsonSerializerOptions);
    }

    private static GraphData BuildGraphData(IReadOnlyList<IPipelineEvent> events)
    {
        Dictionary<string, PipelineNode> pipelines = [];
        Dictionary<string, StageNode> stages = [];
        List<StepNode> steps = [];
        List<EdgeData> edges = [];

        // Group events by pipeline, then by phase
        Dictionary<string, List<IPipelineEvent>> eventsByPipeline = events
            .GroupBy(e => e.RunContext.Pipeline.Id)
            .ToDictionary(g => g.Key, g => g.OrderBy(e => e.Timestamp).ToList());

        foreach (KeyValuePair<string, List<IPipelineEvent>> pipelineKvp in eventsByPipeline)
        {
            string pipelineId = pipelineKvp.Key;
            List<IPipelineEvent> pipelineEvents = pipelineKvp.Value;

            // Create or get pipeline node
            if (!pipelines.ContainsKey(pipelineId))
            {
                pipelines[pipelineId] = new PipelineNode
                {
                    Id = pipelineId,
                    Name = pipelineId,
                    Type = "pipeline",
                    ParentId = GetParentPipelineId(pipelineEvents.FirstOrDefault()),
                    Stages = []
                };
            }

            // Group events by phase
            Dictionary<string, List<IPipelineEvent>> eventsByPhase = pipelineEvents
                .GroupBy(e => e.PhaseId)
                .ToDictionary(g => g.Key, g => g.OrderBy(e => e.Timestamp).ToList());

            string? previousStageId = null;

            foreach (KeyValuePair<string, List<IPipelineEvent>> phaseKvp in eventsByPhase)
            {
                string phaseId = phaseKvp.Key;
                string stageId = $"{pipelineId}_{phaseId}";
                List<IPipelineEvent> phaseEvents = phaseKvp.Value;

                // Create stage node if it doesn't exist
                if (!stages.TryGetValue(stageId, out StageNode? value))
                {
                    value = new StageNode
                    {
                        Id = stageId,
                        Name = phaseId,
                        Type = "stage",
                        PipelineId = pipelineId,
                        Steps = []
                    };
                    stages[stageId] = value;
                    pipelines[pipelineId].Stages.Add(stageId);
                }

                // Create edge between stages
                if (previousStageId != null)
                {
                    edges.Add(new EdgeData
                    {
                        Id = $"edge_{previousStageId}_to_{stageId}",
                        Source = previousStageId,
                        Target = stageId,
                        Type = "stage-to-stage"
                    });
                }

                previousStageId = stageId;

                // Create step nodes
                string? previousStepId = null;
                List<(PhaseStarted? started, PhaseCompleted? completed, PhaseFailed? failed)> stepEventPairs = [];

                // Match Started events with Completed/Failed events
                List<PhaseStarted> startedEvents = [.. phaseEvents.OfType<PhaseStarted>()];
                List<PhaseCompleted> completedEvents = [.. phaseEvents.OfType<PhaseCompleted>()];
                List<PhaseFailed> failedEvents = [.. phaseEvents.OfType<PhaseFailed>()];

                foreach (PhaseStarted startedEvent in startedEvents)
                {
                    PhaseCompleted? matchingCompleted = completedEvents.FirstOrDefault(c =>
                        c.PhaseId == startedEvent.PhaseId &&
                        c.ModuleId == startedEvent.ModuleId &&
                        c.ItemId == startedEvent.ItemId);

                    PhaseFailed? matchingFailed = failedEvents.FirstOrDefault(f =>
                        f.PhaseId == startedEvent.PhaseId &&
                        f.ModuleId == startedEvent.ModuleId &&
                        f.ItemId == startedEvent.ItemId);

                    stepEventPairs.Add((startedEvent, matchingCompleted, matchingFailed));
                }

                // Handle orphan completed/failed events (those without a matching started)
                foreach (PhaseCompleted? completedEvent in completedEvents)
                {
                    if (!stepEventPairs.Any(p => p.completed == completedEvent))
                    {
                        stepEventPairs.Add((null, completedEvent, null));
                    }
                }

                foreach (PhaseFailed? failedEvent in failedEvents)
                {
                    if (!stepEventPairs.Any(p => p.failed == failedEvent))
                    {
                        stepEventPairs.Add((null, null, failedEvent));
                    }
                }

                foreach ((PhaseStarted? started, PhaseCompleted? completed, PhaseFailed? failed) in stepEventPairs)
                {
                    IPipelineEvent? baseEvent = (IPipelineEvent?)started ?? (IPipelineEvent?)completed ?? failed;
                    if (baseEvent == null)
                    {
                        continue;
                    }

                    string stepId = $"{stageId}_{baseEvent.ModuleId}_{baseEvent.ItemId}_{baseEvent.Timestamp.Ticks}";

                    string status = failed != null ? "failed" : completed != null ? "completed" : "started";
                    double duration = completed?.Duration.TotalMilliseconds ?? 0;
                    string? errorMessage = failed?.Exception.Message;

                    StepNode step = new()
                    {
                        Id = stepId,
                        Name = $"{baseEvent.PhaseId}",
                        Type = "step",
                        StageId = stageId,
                        ModuleId = baseEvent.ModuleId ?? "unknown",
                        ItemId = baseEvent.ItemId,
                        Status = status,
                        Duration = duration,
                        StartTime = started?.Timestamp.ToString("o"),
                        EndTime = (completed?.Timestamp ?? failed?.Timestamp)?.ToString("o"),
                        ErrorMessage = errorMessage
                    };

                    steps.Add(step);
                    value.Steps.Add(stepId);

                    // Create edge between steps
                    if (previousStepId != null)
                    {
                        edges.Add(new EdgeData
                        {
                            Id = $"edge_{previousStepId}_to_{stepId}",
                            Source = previousStepId,
                            Target = stepId,
                            Type = "step-to-step"
                        });
                    }

                    previousStepId = stepId;
                }
            }
        }

        // Add hierarchy edges (pipeline -> stages, stages -> steps)
        foreach (PipelineNode pipeline in pipelines.Values)
        {
            // Add edges from pipeline to its first stage
            if (pipeline.Stages.Count > 0)
            {
                string firstStageId = pipeline.Stages[0];
                edges.Add(new EdgeData
                {
                    Id = $"edge_{pipeline.Id}_to_{firstStageId}",
                    Source = pipeline.Id,
                    Target = firstStageId,
                    Type = "pipeline-to-stage"
                });
            }
        }

        foreach (StageNode stage in stages.Values)
        {
            // Add edges from stage to its first step
            if (stage.Steps.Count > 0)
            {
                string firstStepId = stage.Steps[0];
                edges.Add(new EdgeData
                {
                    Id = $"edge_{stage.Id}_to_{firstStepId}",
                    Source = stage.Id,
                    Target = firstStepId,
                    Type = "stage-to-step"
                });
            }
        }

        // Add pipeline dependency edges (parent pipeline -> child pipeline)
        foreach (PipelineNode pipeline in pipelines.Values)
        {
            if (pipeline.ParentId != null && pipelines.ContainsKey(pipeline.ParentId))
            {
                edges.Add(new EdgeData
                {
                    Id = $"edge_{pipeline.ParentId}_to_{pipeline.Id}",
                    Source = pipeline.ParentId,
                    Target = pipeline.Id,
                    Type = "pipeline-to-pipeline"
                });
            }
        }

        return new GraphData
        {
            Pipelines = [.. pipelines.Values],
            Stages = [.. stages.Values],
            Steps = steps,
            Edges = edges
        };
    }

    private static string? GetParentPipelineId(IPipelineEvent? evt)
    {
        return evt?.RunContext is ISubPipelineRunContext subContext ? subContext.Parent.Pipeline.Id : null;
    }
}

// Data models for JSON serialization

internal sealed class GraphData
{
    public List<PipelineNode> Pipelines { get; set; } = [];
    public List<StageNode> Stages { get; set; } = [];
    public List<StepNode> Steps { get; set; } = [];
    public List<EdgeData> Edges { get; set; } = [];
}

internal sealed class PipelineNode
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public string? ParentId { get; set; }
    public List<string> Stages { get; set; } = [];
}

internal sealed class StageNode
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required string PipelineId { get; set; }
    public List<string> Steps { get; set; } = [];
}

internal sealed class StepNode
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required string StageId { get; set; }
    public required string ModuleId { get; set; }
    public string? ItemId { get; set; }
    public required string Status { get; set; }
    public double Duration { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public string? ErrorMessage { get; set; }
}

internal sealed class EdgeData
{
    public required string Id { get; set; }
    public required string Source { get; set; }
    public required string Target { get; set; }
    public required string Type { get; set; }
}
