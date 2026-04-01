using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing
{
    internal sealed class BlueprintBuilder(
        IObjectiveBuilder objectiveBuilder,
        IMustConstraintBuilder mustConstraintBuilder,
        IMustNotConstraintBuilder mustNotConstraintBuilder,
        IAssumptionBuilder assumptionBuilder,
        IGlossaryTermBuilder glossaryTermBuilder,
        ICommandBuilder commandBuilder,
        IBlueprintStepBuilder stepBuilder) : IBlueprintBuilder
    {
        private string _id = string.Empty;
        private string _name = string.Empty;
        private string _description = string.Empty;
        private readonly List<IMustConstraint> _mustConstraints = [];
        private readonly List<IMustNotConstraint> _mustNotConstraints = [];
        private readonly List<IObjective> _objectives = [];
        private readonly List<IAssumption> _assumptions = [];
        private readonly List<IGlossaryTerm> _glossary = [];
        private readonly List<ICommand> _commands = [];
        private readonly List<IBlueprintStep> _steps = [];

        public IBlueprint Build()
        {
            return new Blueprint
            {
                Id = _id,
                Name = _name,
                Description = _description,
                MustConstraints = [.. _mustConstraints],
                MustNotConstraints = [.. _mustNotConstraints],
                Objectives = [.. _objectives],
                Assumptions = [.. _assumptions],
                Glossary = [.. _glossary],
                Commands = [.. _commands],
                Steps = [.. _steps]
            };
        }

        public IBlueprintBuilder InitNew()
        {
            _id = string.Empty;
            _name = string.Empty;
            _description = string.Empty;
            _mustConstraints.Clear();
            _mustNotConstraints.Clear();
            _objectives.Clear();
            _assumptions.Clear();
            _glossary.Clear();
            _commands.Clear();
            _steps.Clear();
            return this;
        }

        public IBlueprintBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public IBlueprintBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public IBlueprintBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public IBlueprintBuilder AddMustConstraint(IMustConstraint constraint)
        {
            _mustConstraints.Add(constraint);
            return this;
        }

        public IBlueprintBuilder AddMustConstraints(IEnumerable<IMustConstraint> constraints)
        {
            _mustConstraints.AddRange(constraints);
            return this;
        }

        public IBlueprintBuilder AddMustNotConstraint(IMustNotConstraint constraint)
        {
            _mustNotConstraints.Add(constraint);
            return this;
        }

        public IBlueprintBuilder AddMustNotConstraints(IEnumerable<IMustNotConstraint> constraints)
        {
            _mustNotConstraints.AddRange(constraints);
            return this;
        }

        public IBlueprintBuilder AddObjective(IObjective objective)
        {
            _objectives.Add(objective);
            return this;
        }

        public IBlueprintBuilder AddObjectives(IEnumerable<IObjective> objectives)
        {
            _objectives.AddRange(objectives);
            return this;
        }

        public IBlueprintBuilder AddAssumption(IAssumption assumption)
        {
            _assumptions.Add(assumption);
            return this;
        }

        public IBlueprintBuilder AddAssumptions(IEnumerable<IAssumption> assumptions)
        {
            _assumptions.AddRange(assumptions);
            return this;
        }

        public IBlueprintBuilder AddGlossaryTerm(IGlossaryTerm term)
        {
            _glossary.Add(term);
            return this;
        }

        public IBlueprintBuilder AddGlossaryTerms(IEnumerable<IGlossaryTerm> terms)
        {
            _glossary.AddRange(terms);
            return this;
        }

        public IBlueprintBuilder AddCommand(ICommand command)
        {
            _commands.Add(command);
            return this;
        }

        public IBlueprintBuilder AddCommands(IEnumerable<ICommand> commands)
        {
            _commands.AddRange(commands);
            return this;
        }

        public IBlueprintBuilder AddStep(IBlueprintStep blueprintStep)
        {
            _steps.Add(blueprintStep);
            return this;
        }

        public IBlueprintBuilder AddSteps(IEnumerable<IBlueprintStep> steps)
        {
            _steps.AddRange(steps);
            return this;
        }

        // Lambda-based fluent methods
        public IBlueprintBuilder WithObjective(Func<IObjectiveBuilder, IObjectiveBuilder> configure)
        {
            IObjective objective = configure(objectiveBuilder.InitNew()).Build();
            return AddObjective(objective);
        }

        public IBlueprintBuilder WithGlobalMustConstraint(Func<IMustConstraintBuilder, IMustConstraintBuilder> configure)
        {
            IMustConstraint constraint = configure(mustConstraintBuilder.InitNew()).Build();
            return AddMustConstraint(constraint);
        }

        public IBlueprintBuilder WithGlobalMustNotConstraint(Func<IMustNotConstraintBuilder, IMustNotConstraintBuilder> configure)
        {
            IMustNotConstraint constraint = configure(mustNotConstraintBuilder.InitNew()).Build();
            return AddMustNotConstraint(constraint);
        }

        public IBlueprintBuilder WithAssumption(Func<IAssumptionBuilder, IAssumptionBuilder> configure)
        {
            IAssumption assumption = configure(assumptionBuilder.InitNew()).Build();
            return AddAssumption(assumption);
        }

        public IBlueprintBuilder WithGlossaryTerm(Func<IGlossaryTermBuilder, IGlossaryTermBuilder> configure)
        {
            IGlossaryTerm term = configure(glossaryTermBuilder.InitNew()).Build();
            return AddGlossaryTerm(term);
        }

        public IBlueprintBuilder WithCommand(Func<ICommandBuilder, ICommandBuilder> configure)
        {
            ICommand command = configure(commandBuilder.InitNew()).Build();
            return AddCommand(command);
        }

        public IBlueprintBuilder WithStep(Func<IBlueprintStepBuilder, IBlueprintStepBuilder> configure)
        {
            IBlueprintStep step = configure(stepBuilder.InitNew()).Build();
            return AddStep(step);
        }
    }
}
