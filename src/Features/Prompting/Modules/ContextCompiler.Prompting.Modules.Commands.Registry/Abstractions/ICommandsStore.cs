using ContextCompiler.Abstractions.Common;
using ContextCompiler.Prompting.Modules.Commands.Registry.Models;

namespace ContextCompiler.Prompting.Modules.Commands.Registry.Abstractions;

public interface ICommandsStore
{
    Task<IReadOnlyList<CommandDescriptor>> List(CancellationToken cancellationToken);
    Task<IResult<CommandDescriptor>> TryGet(string id, CancellationToken cancellationToken);
}
