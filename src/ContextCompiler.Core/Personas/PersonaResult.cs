using ContextCompiler.Abstractions.Personas;
using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Personas
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
