using ContextCompiler.Abstractions.Files;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Files;

public static class DependencyInjection
{

    public static IServiceCollection AddFiles(this IServiceCollection services)
    {
        // Register core services here
        services.AddSingleton<IFileContentBuilder, FileContentBuilder>()
                .AddSingleton<IFileReadResultBuilder, FileReadResultBuilder>();
        return services;
    }

}
