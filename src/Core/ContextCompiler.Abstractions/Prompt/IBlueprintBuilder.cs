namespace ContextCompiler.Abstractions.Prompt
{
    public interface IBlueprintBuilder
    {
        IBlueprint Build();
        IBlueprintBuilder InitNew();
        IBlueprintBuilder WithId(string id);
        IBlueprintBuilder WithName(string name);
        IBlueprintBuilder WithDescription(string description);
        IBlueprintBuilder AddMustConstraint(IMustConstraint constraint);
        IBlueprintBuilder AddMustConstraints(IEnumerable<IMustConstraint> constraints);
        IBlueprintBuilder AddMustNotConstraint(IMustNotConstraint constraint);
        IBlueprintBuilder AddMustNotConstraints(IEnumerable<IMustNotConstraint> constraints);
        IBlueprintBuilder AddObjective(IObjective objective);
        IBlueprintBuilder AddObjectives(IEnumerable<IObjective> objectives);
        IBlueprintBuilder AddAssumption(IAssumption assumption);
        IBlueprintBuilder AddAssumptions(IEnumerable<IAssumption> assumptions);
        IBlueprintBuilder AddGlossaryTerm(IGlossaryTerm term);
        IBlueprintBuilder AddGlossaryTerms(IEnumerable<IGlossaryTerm> terms);
        IBlueprintBuilder AddCommand(ICommand command);
        IBlueprintBuilder AddCommands(IEnumerable<ICommand> commands);
        IBlueprintBuilder AddStep(IBlueprintStep blueprintStep);
        IBlueprintBuilder AddSteps(IEnumerable<IBlueprintStep> steps);
    }
}
