using ContextCompiler.Abstractions.Storage;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ContextCompiler.Core.Storage;

public static class DependencyInjection
{

    public static IServiceCollection AddStorage(this IServiceCollection services)
    {
        // Register core services here
        services.TryAddSingleton<IStoreConfigurationBuilder, StoreConfigurationBuilder>();

        return services;
    }

}
