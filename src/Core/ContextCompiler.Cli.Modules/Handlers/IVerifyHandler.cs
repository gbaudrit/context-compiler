namespace ContextCompiler.Cli.Modules.Handlers;

public interface IVerifyHandler
{
    Task<int> HandleAsync(string cfgFile);
}
