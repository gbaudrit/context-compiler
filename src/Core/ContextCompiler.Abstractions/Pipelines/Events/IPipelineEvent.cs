namespace ContextCompiler.Abstractions.Pipelines.Events;

public interface IPipelineEvent
{
    string Name => GetType().Name;
    string PipelineId { get; }
    string PhaseId { get; }
    DateTimeOffset Timestamp { get; }
}

public sealed record PhaseStarted(
    string PipelineId,
    string PhaseId,
    string ModuleId,
    DateTimeOffset Timestamp
) : IPipelineEvent;

public sealed record PhaseCompleted(
    string PipelineId,
    string PhaseId,
    string ModuleId,
    TimeSpan Duration,
    DateTimeOffset Timestamp
) : IPipelineEvent;

public sealed record PhaseFailed(
    string PipelineId,
    string PhaseId,
    string ModuleId,
    Exception Exception,
    DateTimeOffset Timestamp
) : IPipelineEvent;
