using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Core.Pipelines.DataPart;
using ContextCompiler.Core.Pipelines.Document;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Pipelines
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPipelines(this IServiceCollection services)
        {
            // Register core services here
            services.AddSingleton<IGlobalPipelineRunner, GlobalPipelineRunner>()
                .AddSingleton<IDocumentContextBuilder, DocumentContextBuilder>()
                .AddDocumentPipeline()
                .AddDataPartPipeline();
            return services;
        }

    }
}
