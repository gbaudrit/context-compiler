namespace ContextCompiler.Plugins.Cli.Handlers;

public interface IListHandler
{
    Task<int> HandleAsync(string cfgFile);
}
