using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.DataPart;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Core.Pipelines.Document;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Pipelines.DataPart;

public static class DependencyInjection
{

    public static IServiceCollection AddDataPartPipeline(this IServiceCollection services)
    {
        // Register core services here
        services.AddSingleton<IDataPartPipelineRunner, DataPartPipelineRunner>();

        services.AddSingleton<IDataPartPass, EngineeringModulesPass>()
            .AddSingleton<IDataPartPass, FragmentGuardsPass>()
            .AddSingleton<IDataPartPass, TranscodingPass>();

        return services;
    }

}
