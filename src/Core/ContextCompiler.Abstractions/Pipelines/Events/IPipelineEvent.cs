namespace ContextCompiler.Abstractions.Pipelines.Events;

public interface IPipelineEvent
{
    string Name => GetType().Name;
    IPipelineRunContext RunContext { get; }
    string PhaseId { get; }
    string ModuleId { get; }
    string ItemId { get; }
    DateTimeOffset Timestamp { get; }
}

public sealed record PhaseStarted(
    IPipelineRunContext RunContext,
    string PhaseId,
    string ModuleId,
    string ItemId,
    DateTimeOffset Timestamp
) : IPipelineEvent;

public sealed record PhaseCompleted(
    IPipelineRunContext RunContext,
    string PhaseId,
    string ModuleId,
    string ItemId,
    TimeSpan Duration,
    DateTimeOffset Timestamp
) : IPipelineEvent;

public sealed record PhaseFailed(
    IPipelineRunContext RunContext,
    string PhaseId,
    string ModuleId,
    string ItemId,
    Exception Exception,
    DateTimeOffset Timestamp
) : IPipelineEvent;
