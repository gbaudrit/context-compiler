using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Framing
{
    internal sealed class BlueprintStepBuilder(
        IMustConstraintBuilder mustConstraintBuilder,
        IMustNotConstraintBuilder mustNotConstraintBuilder) : IBlueprintStepBuilder
    {
        private string _title = string.Empty;
        private string _description = string.Empty;
        private string _expectedOutcome = string.Empty;
        private string _content = string.Empty;
        private readonly List<IMustConstraint> _mustConstraints = [];
        private readonly List<IMustNotConstraint> _mustNotConstraints = [];

        public IBlueprintStep Build()
        {
            return new BlueprintStep
            {
                Title = _title,
                Description = _description,
                ExpectedOutcome = _expectedOutcome,
                Content = _content,
                MustConstraints = [.. _mustConstraints],
                MustNotConstraints = [.. _mustNotConstraints]
            };
        }

        public IBlueprintStepBuilder InitNew()
        {
            _title = string.Empty;
            _description = string.Empty;
            _expectedOutcome = string.Empty;
            _content = string.Empty;
            _mustConstraints.Clear();
            _mustNotConstraints.Clear();
            return this;
        }

        public IBlueprintStepBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public IBlueprintStepBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public IBlueprintStepBuilder WithExpectedOutcome(string expectedOutcome)
        {
            _expectedOutcome = expectedOutcome;
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

        public IBlueprintStepBuilder WithMustConstraint(Func<IMustConstraintBuilder, IMustConstraintBuilder> configure)
        {
            IMustConstraint constraint = configure(mustConstraintBuilder.InitNew()).Build();
            return AddMustConstraint(constraint);
        }

        public IBlueprintStepBuilder WithMustNotConstraint(Func<IMustNotConstraintBuilder, IMustNotConstraintBuilder> configure)
        {
            IMustNotConstraint constraint = configure(mustNotConstraintBuilder.InitNew()).Build();
            return AddMustNotConstraint(constraint);
        }
    }
}
