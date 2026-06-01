using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Events;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Events;

internal sealed class PipelineEventPublisher(
    IEnumerable<IPipelineEventHandler<PhaseStarted>> phaseStartedHandlers,
    IEnumerable<IPipelineEventHandler<PhaseCompleted>> phaseCompletedHandlers,
    IEnumerable<IPipelineEventHandler<PhaseFailed>> phaseFailedHandlers,
    ILogger<PipelineEventPublisher> logger) : IPipelineEventPublisher
{
    public async Task<IPipelineEvent> PublishAsync<TEvent>(TEvent e, CancellationToken cancellationToken = default)
        where TEvent : IPipelineEvent
    {
        cancellationToken.ThrowIfCancellationRequested();

        logger.LogInformation(
            "Pipeline event: {EventType} | Pipeline: {PipelineId} | Phase: {PhaseId} | Timestamp: {Timestamp}",
            e.GetType().Name,
            e.RunContext.Pipeline.Id,
            e.PhaseId,
            e.Timestamp);

        if (e is PhaseStarted started)
        {
            logger.LogInformation("Phase started: Module {ModuleId}", started.ModuleId);

            foreach (IPipelineEventHandler<PhaseStarted> handler in phaseStartedHandlers)
            {
                await handler.HandleAsync(started, cancellationToken);
            }
        }
        else if (e is PhaseCompleted completed)
        {
            logger.LogInformation("Phase completed: Module {ModuleId} in {Duration}ms",
                completed.ModuleId,
                completed.Duration.TotalMilliseconds);

            foreach (IPipelineEventHandler<PhaseCompleted> handler in phaseCompletedHandlers)
            {
                await handler.HandleAsync(completed, cancellationToken);
            }
        }
        else if (e is PhaseFailed failed)
        {
            logger.LogError(failed.Exception,
                "Phase failed: Module {ModuleId}",
                failed.ModuleId);

            foreach (IPipelineEventHandler<PhaseFailed> handler in phaseFailedHandlers)
            {
                await handler.HandleAsync(failed, cancellationToken);
            }
        }

        return e;
    }

    public Task<IPipelineEvent> PublishPhaseStartedAsync(
        IPipelineRunContext pipeline,
        string phaseId,
        string moduleId,
        string itemId,
        CancellationToken cancellationToken = default)
    {
        PhaseStarted e = new(
            pipeline,
            phaseId,
            moduleId,
            itemId,
            DateTimeOffset.UtcNow);

        return PublishAsync(e, cancellationToken);
    }

    public Task<IPipelineEvent> PublishPhaseCompletedAsync(
        IPipelineRunContext pipeline,
        string phaseId,
        string moduleId,
        string itemId,
        TimeSpan duration,
        CancellationToken cancellationToken = default)
    {
        PhaseCompleted e = new(
            pipeline,
            phaseId,
            moduleId,
            itemId,
            duration,
            DateTimeOffset.UtcNow);

        return PublishAsync(e, cancellationToken);
    }

    public Task<IPipelineEvent> PublishPhaseCompletedAsync(
            IPipelineRunContext pipeline,
            string phaseId,
            string moduleId,
            string itemId,
            IPipelineEvent startEvent,
            CancellationToken cancellationToken = default)
    {

        TimeSpan duration = DateTimeOffset.UtcNow - startEvent.Timestamp;

        PhaseCompleted e = new(
            pipeline,
            phaseId,
            moduleId,
            itemId,
            duration,
            DateTimeOffset.UtcNow);

        return PublishAsync(e, cancellationToken);
    }

    public Task<IPipelineEvent> PublishPhaseFailedAsync(
        IPipelineRunContext pipeline,
        string phaseId,
        string moduleId,
        string itemId,
        Exception exception,
        CancellationToken cancellationToken = default)
    {
        PhaseFailed e = new(
            pipeline,
            phaseId,
            moduleId,
            itemId,
            exception,
            DateTimeOffset.UtcNow);

        return PublishAsync(e, cancellationToken);
    }

    public Task<T> PublishPhaseAsync<T>(
        IPipelineRunContext pipeline,
        string phaseId,
        string moduleId,
        Func<Task<T>> action,
        CancellationToken cancellationToken = default)
    {
        return PublishPhaseAsync(pipeline, phaseId, moduleId, string.Empty, action, cancellationToken);
    }

    public async Task<T> PublishPhaseAsync<T>(
        IPipelineRunContext pipeline,
        string phaseId,
        string moduleId,
        string itemId,
        Func<Task<T>> action,
        CancellationToken cancellationToken = default)
    {
        IPipelineEvent startEvent = await PublishPhaseStartedAsync(pipeline, phaseId, moduleId, itemId, cancellationToken);

        try
        {
            T result = await action();

            _ = await PublishPhaseCompletedAsync(pipeline, phaseId, moduleId, itemId, startEvent, cancellationToken);

            return result;
        }
        catch (Exception ex)
        {
            _ = await PublishPhaseFailedAsync(pipeline, phaseId, moduleId, itemId, ex, cancellationToken);
            throw;
        }
    }

    public Task PublishPhaseAsync(
        IPipelineRunContext pipeline,
        string phaseId,
        string moduleId,
        Func<Task> action,
        CancellationToken cancellationToken = default)
    {
        return PublishPhaseAsync(pipeline, phaseId, moduleId, string.Empty, action, cancellationToken);
    }

    public async Task PublishPhaseAsync(
        IPipelineRunContext pipeline,
        string phaseId,
        string moduleId,
        string itemId,
        Func<Task> action,
        CancellationToken cancellationToken = default)
    {
        IPipelineEvent startEvent = await PublishPhaseStartedAsync(pipeline, phaseId, moduleId, itemId, cancellationToken);

        try
        {
            await action();

            _ = await PublishPhaseCompletedAsync(pipeline, phaseId, moduleId, itemId, startEvent, cancellationToken);
        }
        catch (Exception ex)
        {
            _ = await PublishPhaseFailedAsync(pipeline, phaseId, moduleId, itemId, ex, cancellationToken);
            throw;
        }
    }
}
