namespace ContextCompiler.Abstractions.Pipelines.Events;

public interface IPipelineEventHandler<in TEvent>
    where TEvent : IPipelineEvent
{
    ValueTask HandleAsync(TEvent e, CancellationToken cancellationToken);
}
