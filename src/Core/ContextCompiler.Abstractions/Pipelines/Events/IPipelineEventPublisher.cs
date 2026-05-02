namespace ContextCompiler.Abstractions.Pipelines.Events;

public interface IPipelineEventPublisher
{
    Task<IPipelineEvent> PublishAsync<TEvent>(
        TEvent e,
        CancellationToken cancellationToken = default)
        where TEvent : IPipelineEvent;

    Task<IPipelineEvent> PublishPhaseStartedAsync(
        IPipeline pipeline,
        string phaseId,
        string moduleId,
        CancellationToken cancellationToken = default);

    Task<IPipelineEvent> PublishPhaseCompletedAsync(
        IPipeline pipeline,
        string phaseId,
        string moduleId,
        TimeSpan duration,
        CancellationToken cancellationToken = default);

    Task<IPipelineEvent> PublishPhaseFailedAsync(
        IPipeline pipeline,
        string phaseId,
        string moduleId,
        Exception exception,
        CancellationToken cancellationToken = default);

    Task<T> PublishPhaseAsync<T>(
        IPipeline pipeline,
        string phaseId,
        string moduleId,
        Func<Task<T>> action,
        CancellationToken cancellationToken = default);

    Task PublishPhaseAsync(
        IPipeline pipeline,
        string phaseId,
        string moduleId,
        Func<Task> action,
        CancellationToken cancellationToken = default);
}
