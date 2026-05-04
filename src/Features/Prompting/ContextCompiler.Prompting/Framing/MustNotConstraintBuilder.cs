using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Framing
{
    internal sealed class MustNotConstraintBuilder : IMustNotConstraintBuilder
    {
        private string? _id;
        private string? _rationale;
        private string? _text;

        public IMustNotConstraintBuilder InitNew()
        {
            _id = null;
            _rationale = null;
            _text = null;
            return this;
        }

        public IMustNotConstraintBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public IMustNotConstraintBuilder WithRationale(string rationale)
        {
            _rationale = rationale;
            return this;
        }

        public IMustNotConstraintBuilder WithText(string text)
        {
            _text = text;
            return this;
        }

        public IMustNotConstraint Build()
        {
            return new MustNotConstraint()
            {
                Id = _id ?? string.Empty,
                Rationale = _rationale ?? string.Empty,
                Text = _text ?? string.Empty
            };
        }
    }
}
