using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Abstractions.Commands;

public interface ICommandsProvider
{
    IReadOnlyList<ICommand> Commands { get; }

    void AddCommand(ICommand command);
}
