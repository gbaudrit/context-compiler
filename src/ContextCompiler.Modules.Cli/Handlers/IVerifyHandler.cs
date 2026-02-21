namespace ContextCompiler.Modules.Cli.Handlers;

public interface IVerifyHandler
{
    Task<int> HandleAsync(string cfgFile);
}
