namespace ContextCompiler.Modules.Cli.Handlers;

public interface IRestoreHandler
{
    Task<int> HandleAsync(bool debug, string cfgFile);
}
