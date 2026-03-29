namespace ContextCompiler.Cli.Handlers;

internal sealed record ServeRequest();

internal interface IServeHandler
{
    Task<int> HandleAsync(ServeRequest request);
}
