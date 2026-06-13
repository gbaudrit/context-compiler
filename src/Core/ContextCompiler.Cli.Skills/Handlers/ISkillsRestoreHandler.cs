namespace ContextCompiler.Cli.Skills.Handlers;

public interface ISkillsRestoreHandler
{
    Task<int> HandleAsync(CancellationToken cancellationToken);
}
