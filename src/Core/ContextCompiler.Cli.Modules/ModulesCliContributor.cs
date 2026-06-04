using System.CommandLine;

using ContextCompiler.Abstractions.Cli;

namespace ContextCompiler.Cli.Modules;

internal sealed class ModulesCliContributor : ICliCommandContributor
{
    public Command Build(IServiceProvider services)
    {
        return CliCommandFactory.BuildModulesCommand(services);
    }
}
