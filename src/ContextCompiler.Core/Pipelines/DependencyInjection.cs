using ContextCompiler.Abstractions.Pipelines;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Pipelines
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPipelinesServices(this IServiceCollection services)
        {
            // Register core services here
            services.AddSingleton<IDocumentPipelineRunner, DocumentPipelineRunner>()
                .AddSingleton<IGlobalPipelineRunner, GlobalPipelineRunner>();
            return services;
        }

    }
}
