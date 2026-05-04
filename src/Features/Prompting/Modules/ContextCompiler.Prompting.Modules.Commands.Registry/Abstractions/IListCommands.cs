using ContextCompiler.Prompting.Modules.Commands.Registry.Models;

namespace ContextCompiler.Prompting.Modules.Commands.Registry.Abstractions;

public interface IListCommands
{
    Task<IReadOnlyList<CommandDescriptor>> Execute(CancellationToken cancellationToken);
}
