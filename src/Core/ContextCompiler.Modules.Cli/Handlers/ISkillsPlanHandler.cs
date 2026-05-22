namespace ContextCompiler.Modules.Cli.Handlers;

internal interface ISkillsPlanHandler
{
    Task<int> HandleAsync(string cfgFile);
}
