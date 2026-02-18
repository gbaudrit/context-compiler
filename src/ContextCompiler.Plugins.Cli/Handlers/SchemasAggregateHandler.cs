using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Plugins.Abstractions;
using ContextCompiler.Plugins.Abstractions.Configuration;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.Cli.Handlers;

internal sealed class SchemasAggregateHandler(
    IPluginManager pluginManager,
    IPluginsLoadConfigLocator pluginsLoadConfigLocator,
    IPluginsLoadConfigProvider pluginsLoadConfigProvider,
    IConfigurationSchemasAggregator configurationSchemasAggregator,
    ISchemaBuilder schemaBuilder,
    IWorkingFolder workingFolder,
    IConfigurationSchemaAggregator configurationSchemaAggregator,
    ILogger<SchemasAggregateHandler> logger
) : ISchemasAggregateHandler
{
    public async Task<int> HandleAsync(string schema1Path, string[] schemasToAggregatePath, string outputPath)
    {
        try
        {
            schema1Path = workingFolder.EnsureFullyQualifiedPath(schema1Path);
            foreach (string schemaToAggregatePath in schemasToAggregatePath)
            {
                string fullyQualifiedPath = workingFolder.EnsureFullyQualifiedPath(schemaToAggregatePath);
                if (!File.Exists(fullyQualifiedPath))
                {
                    logger.LogError("Schema file not found: {SchemaPath}", fullyQualifiedPath);
                    return 2;
                }
            }
            outputPath = workingFolder.EnsureFullyQualifiedPath(outputPath);

            if (!File.Exists(schema1Path))
            {
                logger.LogError("Schema file not found: {SchemaPath}", schema1Path);
                return 1;
            }

            ISchema schema1 = schemaBuilder.InitNew()
                                          .WithName(Path.GetFileNameWithoutExtension(schema1Path))
                                          .WithContent(File.ReadAllText(schema1Path))
                                          .WithPath(schema1Path)
                                          .Build();

            IAggregatedSchema aggregatedSchema = await configurationSchemasAggregator.AggregateSchemas(schema1, [.. schemasToAggregatePath.Select(p => schemaBuilder.InitNew()
                                          .WithName(Path.GetFileNameWithoutExtension(p))
                                          .WithContent(File.ReadAllText(p))
                                          .WithPath(p)
                                          .Build())]);

            File.WriteAllText(outputPath, aggregatedSchema.Content);

            //foreach (string schemaToAggregatePath in schemasToAggregatePath)
            //{

            //    ISchema schema2 = schemaBuilder.InitNew()
            //                              .WithName(Path.GetFileNameWithoutExtension(schemaToAggregatePath))
            //                              .WithContent(File.ReadAllText(schemaToAggregatePath))
            //                              .WithPath(schemaToAggregatePath)
            //                              .Build();

            //    if (configurationSchemaAggregator.CanAggregate(schema2))
            //    {
            //        IAggregatedSchema aggregatedSchema = await configurationSchemaAggregator.Aggregate(main, schema2);
            //        File.WriteAllText(outputPath, aggregatedSchema.Content);
            //        main = aggregatedSchema;
            //    }
            //    else
            //    {
            //        logger.LogError("Schema {SchemaName} cannot be aggregated", schema1.Name);
            //        return 3;
            //    }
            //}
            return 0;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return 5;
        }
    }
}
