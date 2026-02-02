using ContextCompiler.Abstractions.Personas;
using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Personas
{
    internal sealed class PersonaResultBuilder(IMustConstraintBuilder mustConstraintBuilder, IMustNotConstraintBuilder mustNotConstraintBuilder) : IPersonaResultBuilder
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
            int index = 0;
            List<IMustConstraint> mustConstraints = [];
            foreach (string m in must)
            {
                mustConstraints.Add(mustConstraintBuilder.InitNew()
                    .WithId($"MUST{index++}")
                    .WithText(m)
                    .Build());
            }
            _must = [.. mustConstraints];
            return this;
        }

        public IPersonaResultBuilder WithMustNot(IReadOnlyList<IMustNotConstraint> mustNot)
        {
            _mustNot = mustNot;
            return this;
        }

        public IPersonaResultBuilder WithMustNot(IReadOnlyList<string> mustNot)
        {
            int index = 0;
            List<IMustNotConstraint> mustNotConstraints = [];
            foreach (string m in mustNot)
            {
                mustNotConstraints.Add(mustNotConstraintBuilder.InitNew()
                    .WithId($"MUSTNOT{index++}")
                    .WithText(m)
                    .Build());
            }
            _mustNot = [.. mustNotConstraints];
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
                _must ?? [],
                _mustNot ?? []);
        }



    }
}
