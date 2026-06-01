using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Abstractions.Personas
{
    public interface IPersonaBuilder
    {
        IPersona Build();
        IPersonaBuilder InitNew();
        IPersonaBuilder WithFramingMarkdown(string framingMarkdown);
        IPersonaBuilder WithMetadata(IReadOnlyDictionary<string, string> metadata);
        IPersonaBuilder WithMust(IReadOnlyList<IMustConstraint> must);
        IPersonaBuilder WithMust(IReadOnlyList<string> must);
        IPersonaBuilder WithMustNot(IReadOnlyList<IMustNotConstraint> mustNot);
        IPersonaBuilder WithMustNot(IReadOnlyList<string> mustNot);
        IPersonaBuilder WithPersonaId(string personaId);
        IPersonaBuilder WithRole(string role);
        IPersonaBuilder WithTitle(string title);
    }
}
