namespace ContextCompiler.Abstractions.Pipelines.Events;

public interface IPipelineEventPublisher
{
    Task<IPipelineEvent> PublishAsync<TEvent>(
        TEvent e,
        CancellationToken cancellationToken = default)
        where TEvent : IPipelineEvent;

    Task<IPipelineEvent> PublishPhaseStartedAsync(
        IPipelineRunContext pipeline,
        string phaseId,
        string moduleId,
        string itemId,
        CancellationToken cancellationToken = default);

    Task<IPipelineEvent> PublishPhaseCompletedAsync(
        IPipelineRunContext pipeline,
        string phaseId,
        string moduleId,
        string itemId,
        TimeSpan duration,
        CancellationToken cancellationToken = default);

    Task<IPipelineEvent> PublishPhaseFailedAsync(
        IPipelineRunContext pipeline,
        string phaseId,
        string moduleId,
        string itemId,
        Exception exception,
        CancellationToken cancellationToken = default);

    Task<T> PublishPhaseAsync<T>(
        IPipelineRunContext pipeline,
        string phaseId,
        string moduleId,
        Func<Task<T>> action,
        CancellationToken cancellationToken = default);

    Task PublishPhaseAsync(
        IPipelineRunContext pipeline,
        string phaseId,
        string moduleId,
        Func<Task> action,
        CancellationToken cancellationToken = default);

    Task<T> PublishPhaseAsync<T>(
        IPipelineRunContext pipeline,
        string phaseId,
        string moduleId,
        string itemId,
        Func<Task<T>> action,
        CancellationToken cancellationToken = default);

    Task PublishPhaseAsync(
        IPipelineRunContext pipeline,
        string phaseId,
        string moduleId,
        string itemId,
        Func<Task> action,
        CancellationToken cancellationToken = default);
}
