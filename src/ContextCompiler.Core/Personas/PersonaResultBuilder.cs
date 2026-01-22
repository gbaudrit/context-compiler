using ContextCompiler.Abstractions.Personas;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Core.Framing;

namespace ContextCompiler.Core.Personas
{
    internal sealed class PersonaResultBuilder : IPersonaResultBuilder
    {

        private string? _personaId;
        private string? _title;
        private string? _role;
        private string? _framingMarkdown;
        private IReadOnlyDictionary<string, string>? _metadata;
        private IReadOnlyList<IMustConstraint>? _must;
        private IReadOnlyList<IMustNotConstraint>? _mustNot;


        public IPersonaResultBuilder InitNew()
        {
            _personaId = null;
            _title = null;
            _role = null;
            _framingMarkdown = null;
            _metadata = null;
            _must = null;
            _mustNot = null;
            return this;
        }

        public IPersonaResultBuilder WithPersonaId(string personaId)
        {
            _personaId = personaId;
            return this;
        }

        public IPersonaResultBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public IPersonaResultBuilder WithRole(string role)
        {
            _role = role;
            return this;
        }

        public IPersonaResultBuilder WithFramingMarkdown(string framingMarkdown)
        {
            _framingMarkdown = framingMarkdown;
            return this;
        }
        public IPersonaResultBuilder WithMetadata(IReadOnlyDictionary<string, string> metadata)
        {
            _metadata = metadata;
            return this;
        }

        public IPersonaResultBuilder WithMust(IReadOnlyList<IMustConstraint> must)
        {
            _must = must;
            return this;
        }

        public IPersonaResultBuilder WithMust(IReadOnlyList<string> must)
        {
            _must = must.Select(m => new MustConstraint() { Text = m}).ToArray();
            return this;
        }

        public IPersonaResultBuilder WithMustNot(IReadOnlyList<IMustNotConstraint> mustNot)
        {
            _mustNot = mustNot;
            return this;
        }

        public IPersonaResultBuilder WithMustNot(IReadOnlyList<string> mustNot)
        {
            _mustNot = mustNot.Select(m => new MustNotConstraint() { Text = m }).ToArray();
            return this;
        }

        public IPersonaResult Build()
        {
            ArgumentNullException.ThrowIfNull(_personaId);
            ArgumentNullException.ThrowIfNull(_title);
            ArgumentNullException.ThrowIfNull(_framingMarkdown);
            return new PersonaResult(
                _personaId,
                _title,
                _role ?? string.Empty,
                _framingMarkdown,
                _metadata ?? new Dictionary<string, string>(),
                _must ?? Array.Empty<IMustConstraint>(),
                _mustNot ?? Array.Empty<IMustNotConstraint>());
        }



    }
}
