namespace ContextCompiler.Modules.Cli.Handlers;

internal interface ISkillsRestoreHandler
{
    Task<int> HandleAsync(string cfgFile);
}
