using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Prompting.Abstractions.Personas;

namespace ContextCompiler.Prompting.Abstractions;

public interface IPersonaModule : IModule
{
    string PersonaId { get; }
    Task<IPersona> BuildAsync(PersonaContext ctx, CancellationToken ct);
}

public sealed record PersonaContext(
    IReadOnlyDictionary<string, object>? Inputs
);
