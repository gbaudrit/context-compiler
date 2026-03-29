using ContextCompiler.Abstractions.Configuration;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Configuration
{
    internal sealed class ConfigurationSchemasAggregator(IServiceProvider serviceProvider, ILogger<ConfigurationSchemasAggregator> logger) : IConfigurationSchemasAggregator
    {

        public async Task<IAggregatedSchema> AggregateSchemas(ISchema mainSchema, List<ISchema> schemas)
        {
            IAggregatedSchema aggregatedSchema = new AggregatedSchema
            {
                Name = mainSchema.Name,
                Content = mainSchema.Content,
                Path = mainSchema.Path
            };

            try
            {
                IEnumerable<IConfigurationSchemaProvider> schemaProviders = serviceProvider.GetServices<IConfigurationSchemaProvider>();

                IEnumerable<IConfigurationSchemaAggregator> aggregators = serviceProvider.GetServices<IConfigurationSchemaAggregator>();

                logger.LogInformation("Processing core schema {CoreSchema} for aggregation", mainSchema.Path);

                foreach (IConfigurationSchemaAggregator schemaAggregator in aggregators)
                {
                    if (schemaAggregator.CanAggregate(mainSchema))
                    {
                        foreach (ISchema schema in schemas)
                        {
                            if (schemaAggregator.CanAggregate(schema))
                            {
                                aggregatedSchema = await schemaAggregator.Aggregate(aggregatedSchema, schema);
                            }
                        }
                    }
                }
            }
            catch
            {
                // best-effort
            }

            return aggregatedSchema;
        }

    }
}
