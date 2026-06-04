namespace ContextCompiler.Cli.Modules.Handlers;

public interface IPurgeHandler
{
    Task<int> HandleAsync(string cfgFile, bool keepLocked);
}
