namespace ContextCompiler.Cli.Modules.Handlers;

public interface IModulesPlanHandler
{
    Task<int> HandleAsync(string cfgFile);
}
