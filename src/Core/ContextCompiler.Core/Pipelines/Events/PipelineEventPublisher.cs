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
            e.PipelineId,
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
        IPipeline pipeline,
        string phaseId,
        string moduleId,
        CancellationToken cancellationToken = default)
    {
        PhaseStarted e = new(
            pipeline.GetType().Name,
            phaseId,
            moduleId,
            DateTimeOffset.UtcNow);

        return PublishAsync(e, cancellationToken);
    }

    public Task<IPipelineEvent> PublishPhaseCompletedAsync(
        IPipeline pipeline,
        string phaseId,
        string moduleId,
        TimeSpan duration,
        CancellationToken cancellationToken = default)
    {
        PhaseCompleted e = new(
            pipeline.GetType().Name,
            phaseId,
            moduleId,
            duration,
            DateTimeOffset.UtcNow);

        return PublishAsync(e, cancellationToken);
    }

    public Task<IPipelineEvent> PublishPhaseCompletedAsync(
            IPipeline pipeline,
            string phaseId,
            string moduleId,
            IPipelineEvent startEvent,
            CancellationToken cancellationToken = default)
    {

        TimeSpan duration = DateTimeOffset.UtcNow - startEvent.Timestamp;

        PhaseCompleted e = new(
            pipeline.GetType().Name,
            phaseId,
            moduleId,
            duration,
            DateTimeOffset.UtcNow);

        return PublishAsync(e, cancellationToken);
    }

    public Task<IPipelineEvent> PublishPhaseFailedAsync(
        IPipeline pipeline,
        string phaseId,
        string moduleId,
        Exception exception,
        CancellationToken cancellationToken = default)
    {
        PhaseFailed e = new(
            pipeline.GetType().Name,
            phaseId,
            moduleId,
            exception,
            DateTimeOffset.UtcNow);

        return PublishAsync(e, cancellationToken);
    }

    public async Task<T> PublishPhaseAsync<T>(
        IPipeline pipeline,
        string phaseId,
        string moduleId,
        Func<Task<T>> action,
        CancellationToken cancellationToken = default)
    {
        IPipelineEvent startEvent = await PublishPhaseStartedAsync(pipeline, phaseId, moduleId, cancellationToken);

        try
        {
            T result = await action();

            _ = await PublishPhaseCompletedAsync(pipeline, phaseId, moduleId, startEvent, cancellationToken);

            return result;
        }
        catch (Exception ex)
        {
            _ = await PublishPhaseFailedAsync(pipeline, phaseId, moduleId, ex, cancellationToken);
            throw;
        }
    }

    public async Task PublishPhaseAsync(
        IPipeline pipeline,
        string phaseId,
        string moduleId,
        Func<Task> action,
        CancellationToken cancellationToken = default)
    {
        IPipelineEvent startEvent = await PublishPhaseStartedAsync(pipeline, phaseId, moduleId, cancellationToken);

        try
        {
            await action();

            _ = await PublishPhaseCompletedAsync(pipeline, phaseId, moduleId, startEvent, cancellationToken);
        }
        catch (Exception ex)
        {
            _ = await PublishPhaseFailedAsync(pipeline, phaseId, moduleId, ex, cancellationToken);
            throw;
        }
    }
}
