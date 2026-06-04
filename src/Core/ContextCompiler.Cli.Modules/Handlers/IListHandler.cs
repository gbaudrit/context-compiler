namespace ContextCompiler.Cli.Modules.Handlers;

public interface IListHandler
{
    Task<int> HandleAsync(string cfgFile);
}
