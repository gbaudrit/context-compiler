using ContextCompiler.Abstractions.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Configuration.Json;

public static class DependencyInjection
{

    public static IServiceCollection AddJsonConfiguration(this IServiceCollection services)
    {
        return services.AddSingleton<ICtxcConfigSerializer, CtxcConfigSerializer>()
            .AddTransient<IConfigurationSchemaAggregator, SchemaAggregator>()
            .AddSingleton<IConfigurationSchemaProvider, JsonConfigurationSchemaProvider>()
            .AddTransient<IConfigurationSchemasDiscoverer, JsonConfigurationSchemasDiscoverer>();
    }

}
