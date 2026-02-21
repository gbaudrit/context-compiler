using ContextCompiler.Abstractions.Personas;

namespace ContextCompiler.Modules.Abstractions;

public interface IPersonaModule : IModule
{
    string PersonaId { get; }
    Task<IPersonaResult> BuildAsync(PersonaContext ctx, CancellationToken ct);
}

public sealed record PersonaContext(
    IReadOnlyDictionary<string, object>? Inputs
);
