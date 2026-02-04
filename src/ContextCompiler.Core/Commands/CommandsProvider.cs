using ContextCompiler.Abstractions.Commands;
using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Commands;

internal sealed class CommandsProvider : ICommandsProvider
{

    private readonly List<ICommand> _commands = [];

    public IReadOnlyList<ICommand> Commands => _commands;

    public void AddCommand(ICommand command)
    {
        if (!_commands.Any(c => c.Id == command.Id))
        {
            _commands.Add(command);
        }
    }

}
