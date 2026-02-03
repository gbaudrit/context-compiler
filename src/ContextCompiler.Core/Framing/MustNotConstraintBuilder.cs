using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing
{
    internal sealed class MustNotConstraintBuilder : IMustNotConstraintBuilder
    {
        private string? _id;
        private string? _text;

        public IMustNotConstraintBuilder InitNew()
        {
            _id = null;
            _text = null;
            return this;
        }

        public IMustNotConstraintBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public IMustNotConstraintBuilder WithText(string text)
        {
            _text = text;
            return this;
        }

        public IMustNotConstraint Build()
        {
            return _id is null
                ? throw new InvalidOperationException("MustNotConstraint id is required.")
                : _text is null
                ? throw new InvalidOperationException("MustNotConstraint text is required.")
                : (IMustNotConstraint)new MustNotConstraint() { Id = _id, Text = _text };
        }
    }
}
