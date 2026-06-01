using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Sources;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Configuration.Json;

public static class DependencyInjection
{

    public static IServiceCollection AddJsonConfiguration(this IServiceCollection services)
    {
        return services.AddSingleton<IConfigSerializer, CtxcConfigSerializer>()
            .AddTransient<IConfigurationSchemaAggregator, SchemaAggregator>()
            .AddSingleton<IConfigurationSchemaProvider, JsonConfigurationSchemaProvider>()
            .AddTransient<IConfigurationSchemasDiscoverer, JsonConfigurationSchemasDiscoverer>()
            .AddTransient<ISourceConfigSectionReader, JsonSourceConfigSectionReader>();
    }

}
