namespace ContextCompiler.Prompting.Abstractions.Prompt
{
    public interface IBlueprintStepBuilder
    {
        IBlueprintStep Build();
        IBlueprintStepBuilder InitNew();
        IBlueprintStepBuilder WithTitle(string title);
        IBlueprintStepBuilder WithDescription(string description);
        IBlueprintStepBuilder WithExpectedOutcome(string expectedOutcome);
        IBlueprintStepBuilder WithContent(string content);
        IBlueprintStepBuilder AddMustConstraint(IMustConstraint constraint);
        IBlueprintStepBuilder AddMustConstraints(IEnumerable<IMustConstraint> constraints);
        IBlueprintStepBuilder AddMustNotConstraint(IMustNotConstraint constraint);
        IBlueprintStepBuilder AddMustNotConstraints(IEnumerable<IMustNotConstraint> constraints);
        IBlueprintStepBuilder WithMustConstraint(Func<IMustConstraintBuilder, IMustConstraintBuilder> configure);
        IBlueprintStepBuilder WithMustNotConstraint(Func<IMustNotConstraintBuilder, IMustNotConstraintBuilder> configure);
    }
}
