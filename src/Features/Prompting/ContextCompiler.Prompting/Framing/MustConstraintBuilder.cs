using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Framing
{
    internal sealed class MustConstraintBuilder : IMustConstraintBuilder
    {
        private string? _id;
        private string? _rationale;
        private string? _text;

        public IMustConstraintBuilder InitNew()
        {
            _id = null;
            _rationale = null;
            _text = null;
            return this;
        }

        public IMustConstraintBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public IMustConstraintBuilder WithRationale(string rationale)
        {
            _rationale = rationale;
            return this;
        }

        public IMustConstraintBuilder WithText(string text)
        {
            _text = text;
            return this;
        }

        public IMustConstraint Build()
        {
            return new MustConstraint()
            {
                Id = _id ?? string.Empty,
                Rationale = _rationale ?? string.Empty,
                Text = _text ?? string.Empty
            };
        }
    }
}
