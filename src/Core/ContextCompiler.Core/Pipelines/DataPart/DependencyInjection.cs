using ContextCompiler.Abstractions.Pipelines.DataPart;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ContextCompiler.Core.Pipelines.DataPart;

public static class DependencyInjection
{

    public static IServiceCollection AddDataPartPipeline(this IServiceCollection services)
    {
        // Register core services here
        services.TryAddEnumerable(ServiceDescriptor.Transient<IInputIngestionPipelineModule, DataPartPipelineRunner>());
        return services.AddSingleton<IDataPartDescriptorBuilder, DataPartDescriptorBuilder>()
                       .AddSingleton<IDataPartCatalog, DataPartCatalog>();
    }

}
