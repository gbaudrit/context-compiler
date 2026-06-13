using ContextCompiler.Abstractions.Pipelines.Prepare;
using ContextCompiler.Abstractions.Services.Prepare;
using ContextCompiler.Core.Pipelines.Prepare.Modules;
using ContextCompiler.Core.Pipelines.Prepare.Services;
using ContextCompiler.Modules.Abstractions.Pipelines.Prepare;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ContextCompiler.Core.Pipelines.Prepare;

public static class DependencyInjection
{
    public static IServiceCollection AddPreparePipeline(this IServiceCollection services)
    {
        _ = services
            .AddSingleton<IPreparePipeline, PreparePipeline>()
            .AddTransient<IPreparePipelineRunContextBuilder, PreparePipelineRunContextBuilder>()
            .AddTransient<IPreparePipelineRunResultBuilder, PreparePipelineRunResultBuilder>()
            .AddTransient<IProjectScanner, ProjectScanner>()
            .AddTransient<IProjectClassifier, ProjectClassifier>()
            .AddTransient<IPreparePlanner, PreparePlanner>()
            .AddTransient<IConfigurationRenderer, ConfigurationRenderer>()
            .AddTransient<IInventoryRenderer, InventoryRenderer>()
            .AddTransient<IPrepareReportRenderer, PrepareReportRenderer>();

        services.TryAddEnumerable(ServiceDescriptor.Transient<IPreparePipelineModule, AnalyzeArtifactsHydrationModule>());
        services.TryAddEnumerable(ServiceDescriptor.Transient<IPreparePipelineModule, ConfigurationPlanningModule>());
        services.TryAddEnumerable(ServiceDescriptor.Transient<IPreparePipelineModule, InventoryRenderingModule>());
        services.TryAddEnumerable(ServiceDescriptor.Transient<IPreparePipelineModule, ConfigurationRenderingModule>());
        services.TryAddEnumerable(ServiceDescriptor.Transient<IPreparePipelineModule, PrepareReportModule>());

        return services;
    }
}
