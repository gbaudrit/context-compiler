using ContextCompiler.Infrastructure.Storage;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddDefaultInfrastructure(this IServiceCollection services)
    {
        // Register default implementations for core services here
        return services.AddFileSystemStorage();
    }
}
