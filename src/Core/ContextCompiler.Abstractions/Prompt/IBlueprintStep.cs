namespace ContextCompiler.Abstractions.Prompt
{
    public interface IBlueprintStep
    {
        string Title { get; init; }
        string Description { get; init; }
        string ExpectedOutcome { get; init; }
        string Content { get; init; }
        IReadOnlyList<IMustConstraint> MustConstraints { get; init; }
        IReadOnlyList<IMustNotConstraint> MustNotConstraints { get; init; }
    }
}
