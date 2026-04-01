namespace ContextCompiler.Abstractions.Prompt
{
    public interface IBlueprintStepBuilder
    {
        IBlueprintStep Build();
        IBlueprintStepBuilder InitNew();
        IBlueprintStepBuilder WithContent(string content);
        IBlueprintStepBuilder AddMustConstraint(IMustConstraint constraint);
        IBlueprintStepBuilder AddMustConstraints(IEnumerable<IMustConstraint> constraints);
        IBlueprintStepBuilder AddMustNotConstraint(IMustNotConstraint constraint);
        IBlueprintStepBuilder AddMustNotConstraints(IEnumerable<IMustNotConstraint> constraints);
    }
}
