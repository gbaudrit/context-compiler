using ContextCompiler.Abstractions.Personas;

namespace ContextCompiler.Abstractions.Plugins;

public interface IPersonaPlugin : IPlugin
{
    string PersonaId { get; }
    Task<IPersonaResult> BuildAsync(PersonaContext ctx, CancellationToken ct);
}

public sealed record PersonaContext(
    string RootPath,
    ContextCompiler.Abstractions.ReasoningIR.IReasoningIr Ir,
    IReadOnlyDictionary<string, object>? Inputs
);
