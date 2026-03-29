using ContextCompiler.Abstractions.Files;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Files;

public static class DependencyInjection
{

    public static IServiceCollection AddFiles(this IServiceCollection services)
    {
        // Register core services here
        return services.AddSingleton<IFileContentBuilder, FileContentBuilder>()
                .AddSingleton<IFileReadResultBuilder, FileReadResultBuilder>()
                .AddTransient<ILinearFileReader, LinearDataReader>();
    }

}
