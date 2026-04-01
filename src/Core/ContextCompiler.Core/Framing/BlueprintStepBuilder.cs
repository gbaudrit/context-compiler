using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing
{
    internal sealed class BlueprintStepBuilder : IBlueprintStepBuilder
    {
        private string _content = string.Empty;
        private readonly List<IMustConstraint> _mustConstraints = [];
        private readonly List<IMustNotConstraint> _mustNotConstraints = [];

        public IBlueprintStep Build()
        {
            return new BlueprintStep
            {
                Content = _content,
                MustConstraints = [.. _mustConstraints],
                MustNotConstraints = [.. _mustNotConstraints]
            };
        }

        public IBlueprintStepBuilder InitNew()
        {
            _content = string.Empty;
            _mustConstraints.Clear();
            _mustNotConstraints.Clear();
            return this;
        }

        public IBlueprintStepBuilder WithContent(string content)
        {
            _content = content;
            return this;
        }

        public IBlueprintStepBuilder AddMustConstraint(IMustConstraint constraint)
        {
            _mustConstraints.Add(constraint);
            return this;
        }

        public IBlueprintStepBuilder AddMustConstraints(IEnumerable<IMustConstraint> constraints)
        {
            _mustConstraints.AddRange(constraints);
            return this;
        }

        public IBlueprintStepBuilder AddMustNotConstraint(IMustNotConstraint constraint)
        {
            _mustNotConstraints.Add(constraint);
            return this;
        }

        public IBlueprintStepBuilder AddMustNotConstraints(IEnumerable<IMustNotConstraint> constraints)
        {
            _mustNotConstraints.AddRange(constraints);
            return this;
        }
    }
}
