using System.Diagnostics.CodeAnalysis;

using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Modules.Commands.Registry.Abstractions;
using ContextCompiler.Modules.Commands.Registry.Models;

namespace ContextCompiler.Modules.Commands.Registry;

internal sealed class CommandsStore(
    ICompiledWorkingFolder compiledWorkingFolder,
    ICommandsIndexSerializer commandsIndexSerializer) : ICommandsStore
{
    private const string Filename = "commands.index.json";
    private CommandsIndex? _index;

    [MemberNotNull(nameof(_index))]
    private void EnsureLoaded()
    {
        string filename = Path.Combine(compiledWorkingFolder.Path, Filename);

        if (!Path.Exists(filename))
        {
            throw new InvalidOperationException("Failed to load commands index.");
        }

        _index = commandsIndexSerializer.Deserialize(File.ReadAllText(filename));
    }

    public Task<IReadOnlyList<CommandDescriptor>> List(CancellationToken cancellationToken)
    {
        EnsureLoaded();
        return Task.FromResult(_index.Commands);
    }

    public Task<IResult<CommandDescriptor>> TryGet(string id, CancellationToken cancellationToken)
    {
        EnsureLoaded();

        CommandDescriptor? command = _index.Commands.FirstOrDefault(c => c.Id == id);

        return command is null
            ? Task.FromResult(IResult.Failure<CommandDescriptor>("Not found"))
            : Task.FromResult(IResult.Success(command));
    }
}
