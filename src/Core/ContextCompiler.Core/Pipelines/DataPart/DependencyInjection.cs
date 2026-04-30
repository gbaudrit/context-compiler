using ContextCompiler.Abstractions.Pipelines.DataPart;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Pipelines.DataPart;

public static class DependencyInjection
{

    public static IServiceCollection AddDataPartPipeline(this IServiceCollection services)
    {
        // Register core services here
        return services.AddSingleton<IDocumentPipelineModule, DataPartPipelineRunner>()
                       .AddSingleton<IDataPartDescriptorBuilder, DataPartDescriptorBuilder>()
                       .AddSingleton<IDataPartCatalog, DataPartCatalog>();
    }

}
