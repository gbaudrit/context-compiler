using ContextCompiler.Abstractions.Pipelines.DataPart;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Pipelines.DataPart;

public static class DependencyInjection
{

    public static IServiceCollection AddDataPartPipeline(this IServiceCollection services)
    {
        // Register core services here
        return services.AddSingleton<IDataPartPipelineRunner, DataPartPipelineRunner>()
                       .AddSingleton<IDataPartPass, EngineeringModulesPass>()
                       .AddSingleton<IDataPartPass, FragmentGuardsPass>()
                       .AddSingleton<IDataPartPass, TranscodingPass>();
    }

}
