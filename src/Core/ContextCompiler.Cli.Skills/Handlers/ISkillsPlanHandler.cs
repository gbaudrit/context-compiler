namespace ContextCompiler.Cli.Skills.Handlers;

public interface ISkillsPlanHandler
{
    Task<int> HandleAsync(string cfgFile);
}
