namespace ContextCompiler.Prompting.Modules.Commands.Registry.Models;

public sealed record CommandDescriptor
{
    public required string Id { get; init; }
    public string? Description { get; init; }
    public string? PersonaId { get; init; }
    public IReadOnlyList<string> Aliases { get; init; } = [];
    public IReadOnlyList<string> Arguments { get; init; } = [];
}
