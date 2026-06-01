using ContextCompiler.Abstractions.Pipelines.Events;

namespace ContextCompiler.Reports.Modules.Pipelines.ReactFlow;

/// <summary>
/// Collects pipeline events for generating React Flow visualizations.
/// </summary>
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
}
