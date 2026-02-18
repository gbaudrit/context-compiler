namespace ContextCompiler.Plugins.Cli.Handlers;

public interface IVerifyHandler
{
    Task<int> HandleAsync(string cfgFile);
}
