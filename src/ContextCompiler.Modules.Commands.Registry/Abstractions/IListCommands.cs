using ContextCompiler.Modules.Commands.Registry.Models;

namespace ContextCompiler.Modules.Commands.Registry.Abstractions;

public interface IListCommands
{
    Task<IReadOnlyList<CommandDescriptor>> Execute(CancellationToken cancellationToken);
}
