using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Abstractions.Personas
{
    public interface IPersona
    {
        string PersonaId { get; }
        string Title { get; }
        string Role { get; }
        string FramingMarkdown { get; }
        IReadOnlyDictionary<string, string>? Metadata { get; }
        IReadOnlyList<IMustConstraint> Must { get; }
        IReadOnlyList<IMustNotConstraint> MustNot { get; }
    }
}
