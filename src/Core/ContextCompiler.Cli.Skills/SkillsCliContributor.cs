using System.CommandLine;

using ContextCompiler.Abstractions.Cli;

namespace ContextCompiler.Cli.Skills;

internal sealed class SkillsCliContributor : ICliCommandContributor
{
    public Command Build(IServiceProvider services)
    {
        return CliCommandFactory.BuildSkillsCommand(services);
    }
}
