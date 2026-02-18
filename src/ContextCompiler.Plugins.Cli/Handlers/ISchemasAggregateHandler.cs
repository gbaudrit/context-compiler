namespace ContextCompiler.Plugins.Cli.Handlers;

public interface ISchemasAggregateHandler
{
    Task<int> HandleAsync(string schema1Path, string[] schemasToAggregatePath, string outputPath);
}
