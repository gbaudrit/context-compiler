using ContextCompiler.Abstractions.Pipelines.Events;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Reports.Modules.Pipelines.ReactFlow;

/// <summary>
/// Dependency injection extensions for the React Flow pipeline report module.
/// </summary>
public sealed class DependencyInjection : IDependencyInjection
{
    /// <summary>
    /// Adds the React Flow pipeline report module to the service collection.
    /// This module generates interactive HTML visualizations of pipeline execution using React Flow and ELK.js.
    /// </summary>
    /// <param name="services">The service collection to add the module to.</param>
    /// <returns>The service collection for chaining.</returns>
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        _ = services.AddSingleton<PipelineEventCollector>();

        _ = services.AddSingleton<IPipelineEventHandler<PhaseStarted>>(sp =>
            sp.GetRequiredService<PipelineEventCollector>());

        _ = services.AddSingleton<IPipelineEventHandler<PhaseCompleted>>(sp =>
            sp.GetRequiredService<PipelineEventCollector>());

        _ = services.AddSingleton<IPipelineEventHandler<PhaseFailed>>(sp =>
            sp.GetRequiredService<PipelineEventCollector>());

        return services.AddSingleton<PipelineEventListener>();
    }
}
