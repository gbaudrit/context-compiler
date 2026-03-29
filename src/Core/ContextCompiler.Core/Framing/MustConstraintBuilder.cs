using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing
{
    internal sealed class MustConstraintBuilder : IMustConstraintBuilder
    {
        private string? _id;
        private string? _text;

        public IMustConstraintBuilder InitNew()
        {
            _id = null;
            _text = null;
            return this;
        }

        public IMustConstraintBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public IMustConstraintBuilder WithText(string text)
        {
            _text = text;
            return this;
        }

        public IMustConstraint Build()
        {
            return _id is null
                ? throw new InvalidOperationException("MustConstraint id is required.")
                : _text is null
                ? throw new InvalidOperationException("MustConstraint text is required.")
                : (IMustConstraint)new MustConstraint() { Id = _id, Text = _text };
        }
    }
}
