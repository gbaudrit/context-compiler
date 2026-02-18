namespace ContextCompiler.Plugins.Cli.Handlers;

public interface IPurgeHandler
{
    Task<int> HandleAsync(string cfgFile, bool keepLocked);
}
