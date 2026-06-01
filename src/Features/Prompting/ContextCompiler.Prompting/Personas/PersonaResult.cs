using ContextCompiler.Prompting.Abstractions.Personas;
using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Personas
{
    public sealed record PersonaResult(
        string PersonaId,
        string Title,
        string Role,
        string FramingMarkdown,
        IReadOnlyDictionary<string, string> Metadata,
        IReadOnlyList<IMustConstraint> Must,
        IReadOnlyList<IMustNotConstraint> MustNot
    ) : IPersona;
}
