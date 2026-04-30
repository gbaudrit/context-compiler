using ContextCompiler.Abstractions.Pipelines;
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
            _ = services.AddSingleton<IGlobalPipelineRunner, GlobalPipelineRunner>()
                .AddDocumentPipeline()
                .AddDataPartPipeline();
            return services;
        }

    }
}
