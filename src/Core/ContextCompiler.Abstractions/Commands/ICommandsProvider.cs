using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Abstractions.Commands;

public interface ICommandsProvider
{
    IReadOnlyList<ICommand> Commands { get; }

    void AddCommand(ICommand command);
}
