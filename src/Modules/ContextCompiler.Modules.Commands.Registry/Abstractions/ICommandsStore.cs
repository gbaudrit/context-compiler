using ContextCompiler.Abstractions.Common;
using ContextCompiler.Modules.Commands.Registry.Models;

namespace ContextCompiler.Modules.Commands.Registry.Abstractions;

public interface ICommandsStore
{
    Task<IReadOnlyList<CommandDescriptor>> List(CancellationToken cancellationToken);
    Task<IResult<CommandDescriptor>> TryGet(string id, CancellationToken cancellationToken);
}
