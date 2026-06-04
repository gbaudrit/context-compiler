using ContextCompiler.Abstractions.Pipelines.Events;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ContextCompiler.Reports.Modules.Pipelines.Mermaid;

public sealed class DependencyInjection : IDependencyInjection
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        _ = services.AddSingleton<PipelineEventCollector>();

        _ = services.AddSingleton<IPipelineEventHandler<PhaseStarted>>(sp =>
            sp.GetRequiredService<PipelineEventCollector>());

        _ = services.AddSingleton<IPipelineEventHandler<PhaseCompleted>>(sp =>
            sp.GetRequiredService<PipelineEventCollector>());

        _ = services.AddSingleton<IPipelineEventHandler<PhaseFailed>>(sp =>
            sp.GetRequiredService<PipelineEventCollector>());

        services.TryAddEnumerable(ServiceDescriptor.Transient<ICompilePipelineModule, MermaidPipelineReportModule>());

        return services;
    }
}
