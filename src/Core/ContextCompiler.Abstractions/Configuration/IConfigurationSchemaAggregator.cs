namespace ContextCompiler.Abstractions.Configuration;

public interface IConfigurationSchemaAggregator
{
    Task<IAggregatedSchema> Aggregate(ISchema schema1, ISchema schema2);
    bool CanAggregate(ISchema schema);
}
