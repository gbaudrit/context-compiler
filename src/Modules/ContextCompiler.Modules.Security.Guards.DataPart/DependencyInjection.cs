using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Security.Guards.DataPart;

public static class DependencyInjection
{
    public static IServiceCollection AddDataPartGuardModule(
        this IServiceCollection services,
        Action<DataPartGuardConfig>? configureOptions = null)
    {
        _ = services.AddSingleton<IDocumentPartPipelineModule, DataPartGuardModule>();

        if (configureOptions is not null)
        {
            _ = services.Configure(configureOptions);
        }
        else
        {
            // Register with default configuration
            _ = services.Configure<DataPartGuardConfig>(static _ => { });
        }

        return services;
    }
}
