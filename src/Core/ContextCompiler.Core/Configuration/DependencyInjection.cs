using ContextCompiler.Abstractions.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Configuration
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            // Register core services here
            return services.AddTransient<ISchemaBuilder, SchemaBuilder>()
                           .AddTransient<IConfigurationSchemasAggregator, ConfigurationSchemasAggregator>();
        }
    }
}
