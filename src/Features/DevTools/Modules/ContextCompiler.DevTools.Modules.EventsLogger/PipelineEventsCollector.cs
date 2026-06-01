using ContextCompiler.Abstractions.Pipelines.Events;

namespace ContextCompiler.DevTools.Modules.EventsLogger;

internal sealed class PipelineEventsCollector :
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
            return _events.OrderBy(e => e.Timestamp).ToList().AsReadOnly();
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
