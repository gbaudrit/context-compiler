using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Core.Pipelines.DataPart;
using ContextCompiler.Core.Pipelines.InputIngestion;
using ContextCompiler.Core.Pipelines.Events;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Pipelines
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPipelines(this IServiceCollection services)
        {
            // Register core services here
            _ = services.AddSingleton<IGlobalPipeline, GlobalPipeline>()
                .AddTransient<IInputItemContextBuilder, InputItemContextBuilder>()
                .AddTransient<IInputItemContextDataBuilder, InputItemContextDataBuilder>()
                .AddTransient<IGlobalPipelineRunContextBuilder, GlobalPipelineRunContextBuilder>()
                .AddTransient<IGlobalPipelineRunResultBuilder, GlobalPipelineRunResultBuilder>()
                .AddInputIngestionPipeline()
                .AddDataPartPipeline()
                .AddPipelineEvents();
            return services;
        }

    }
}
