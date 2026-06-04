using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Core.Pipelines.DataPart;
using ContextCompiler.Core.Pipelines.InputIngestion;
using ContextCompiler.Core.Pipelines.Events;
using ContextCompiler.Core.Pipelines.Prepare;

using Microsoft.Extensions.DependencyInjection;
using ContextCompiler.Core.Pipelines.Compile;
using ContextCompiler.Abstractions.Pipelines.Compile;

namespace ContextCompiler.Core.Pipelines
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPipelines(this IServiceCollection services)
        {
            // Register core services here
            _ = services.AddSingleton<ICompilePipeline, CompilePipeline>()
                .AddTransient<IInputItemContextBuilder, InputItemContextBuilder>()
                .AddTransient<IInputItemContextDataBuilder, InputItemContextDataBuilder>()
                .AddTransient<ICompilePipelineRunContextBuilder, CompilePipelineRunContextBuilder>()
                .AddTransient<ICompilePipelineRunResultBuilder, CompilePipelineRunResultBuilder>()
                .AddInputIngestionPipeline()
                .AddDataPartPipeline()
                .AddPreparePipeline()
                .AddPipelineEvents();
            return services;
        }

    }
}
