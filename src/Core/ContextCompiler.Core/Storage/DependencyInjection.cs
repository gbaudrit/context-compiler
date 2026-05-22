using ContextCompiler.Abstractions.Storage;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Storage;

public static class DependencyInjection
{

    public static IServiceCollection AddStorage(this IServiceCollection services)
    {
        // Register core services here
        return services.AddSingleton<IStoreConfigurationBuilder, StoreConfigurationBuilder>();
    }

}
