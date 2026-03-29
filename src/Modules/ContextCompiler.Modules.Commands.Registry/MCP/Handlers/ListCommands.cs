using ContextCompiler.Modules.Commands.Registry.Abstractions;
using ContextCompiler.Modules.Commands.Registry.Models;

namespace ContextCompiler.Modules.Commands.Registry.MCP.Handlers;

internal sealed class ListCommands(ICommandsStore commandsStore) : IListCommands
{
    public Task<IReadOnlyList<CommandDescriptor>> Execute(CancellationToken cancellationToken)
    {
        return commandsStore.List(cancellationToken);
    }
}
