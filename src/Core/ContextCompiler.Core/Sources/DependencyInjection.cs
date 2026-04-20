using ContextCompiler.Abstractions.Sources;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Sources;

public static class DependencyInjection
{

    public static IServiceCollection AddSources(this IServiceCollection services)
    {
        // Register core services here
        return services.AddSingleton<ISourceConfigProvider, SourceConfigProvider>()
            .AddSingleton<ISourcesProvider, SourcesProvider>()
            .AddTransient<ISourceBuilder, SourceBuilder>();
    }

}
