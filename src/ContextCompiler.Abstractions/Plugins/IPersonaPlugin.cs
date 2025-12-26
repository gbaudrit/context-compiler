namespace ContextCompiler.Abstractions.Plugins;

public interface IPersonaPlugin : IPlugin
{
    string PersonaId { get; }
    Task<PersonaResult> BuildAsync(PersonaContext ctx, CancellationToken ct);
}

public sealed record PersonaContext(
    string RootPath,
    ContextCompiler.Abstractions.ReasoningIR.IReasoningIr Ir,
    IReadOnlyDictionary<string, object>? Inputs
);

public sealed record PersonaResult(
    string PersonaId,
    string Title,
    string FramingMarkdown,
    IReadOnlyDictionary<string, string>? Metadata
);
