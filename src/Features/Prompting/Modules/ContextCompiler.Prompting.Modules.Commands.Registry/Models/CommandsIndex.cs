namespace ContextCompiler.Prompting.Modules.Commands.Registry.Models;

public sealed record CommandsIndex
{
    public IReadOnlyList<CommandDescriptor> Commands { get; init; } = [];
}
