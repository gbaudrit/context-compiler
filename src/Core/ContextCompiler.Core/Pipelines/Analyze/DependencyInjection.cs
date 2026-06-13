using ContextCompiler.Abstractions.Pipelines.Analyze;
using ContextCompiler.Abstractions.Services.Analyze;
using ContextCompiler.Core.Pipelines.Analyze.Modules;
using ContextCompiler.Core.Pipelines.Analyze.Services;
using ContextCompiler.Modules.Abstractions.Pipelines.Analyze;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ContextCompiler.Core.Pipelines.Analyze;

public static class DependencyInjection
{
    public static IServiceCollection AddAnalyzePipeline(this IServiceCollection services)
    {
        _ = services
            .AddSingleton<IAnalyzePipeline, AnalyzePipeline>()
            .AddTransient<IAnalyzePipelineRunContextBuilder, AnalyzePipelineRunContextBuilder>()
            .AddTransient<IAnalyzePipelineRunResultBuilder, AnalyzePipelineRunResultBuilder>()
            .AddTransient<IAnalyzePlanner, AnalyzePlanner>()
            .AddTransient<IAnalyzeRenderer, AnalyzeRenderer>();

        services.TryAddEnumerable(ServiceDescriptor.Transient<IPrepareModuleRecommendationProvider, JsonPrepareModuleRecommendationProvider>());

        services.TryAddEnumerable(ServiceDescriptor.Transient<IAnalyzePipelineModule, ProjectInventoryModule>());
        services.TryAddEnumerable(ServiceDescriptor.Transient<IAnalyzePipelineModule, ProjectClassificationModule>());
        services.TryAddEnumerable(ServiceDescriptor.Transient<IAnalyzePipelineModule, PrepareModulePlanningModule>());
        services.TryAddEnumerable(ServiceDescriptor.Transient<IAnalyzePipelineModule, AnalyzeReportModule>());

        return services;
    }
}
