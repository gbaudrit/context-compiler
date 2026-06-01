namespace ContextCompiler.Modules.Cli.Handlers;

public interface IListHandler
{
    Task<int> HandleAsync(string cfgFile);
}
