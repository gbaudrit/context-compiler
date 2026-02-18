
namespace ContextCompiler.Abstractions.Configuration;

public interface IConfigurationSchemasAggregator
{
    Task<IAggregatedSchema> AggregateSchemas(ISchema mainSchema, List<ISchema> schemas);
}
