using ContextCompiler.Abstractions.Pipelines.Events;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ContextCompiler.DevTools.Modules.EventsLogger;

public sealed class DependencyInjection : IDependencyInjection
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        _ = services.AddSingleton<PipelineEventsCollector>();

        _ = services.AddSingleton<IPipelineEventHandler<PhaseStarted>>(sp =>
            sp.GetRequiredService<PipelineEventsCollector>());

        _ = services.AddSingleton<IPipelineEventHandler<PhaseCompleted>>(sp =>
            sp.GetRequiredService<PipelineEventsCollector>());

        _ = services.AddSingleton<IPipelineEventHandler<PhaseFailed>>(sp =>
            sp.GetRequiredService<PipelineEventsCollector>());

        services.TryAddEnumerable(ServiceDescriptor.Transient<ICompilePipelineModule, EventsLoggerModule>());

        return services;
    }
}
