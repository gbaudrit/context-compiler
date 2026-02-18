namespace ContextCompiler.Plugins.Cli.Handlers;

public interface IRestoreHandler
{
    Task<int> HandleAsync(bool debug, string cfgFile);
}
