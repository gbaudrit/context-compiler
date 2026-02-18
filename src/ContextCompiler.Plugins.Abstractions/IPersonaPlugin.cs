using ContextCompiler.Abstractions.Personas;

namespace ContextCompiler.Plugins.Abstractions;

public interface IPersonaPlugin : IPlugin
{
    string PersonaId { get; }
    Task<IPersonaResult> BuildAsync(PersonaContext ctx, CancellationToken ct);
}

public sealed record PersonaContext(
    IReadOnlyDictionary<string, object>? Inputs
);
