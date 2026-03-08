using ContextCompiler.Abstractions.Personas;

namespace ContextCompiler.Modules.Abstractions;

public interface IPersonaModule : IModule
{
    string PersonaId { get; }
    Task<IPersona> BuildAsync(PersonaContext ctx, CancellationToken ct);
}

public sealed record PersonaContext(
    IReadOnlyDictionary<string, object>? Inputs
);
