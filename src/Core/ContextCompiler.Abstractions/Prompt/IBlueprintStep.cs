namespace ContextCompiler.Abstractions.Prompt
{
    public interface IBlueprintStep
    {
        string Content { get; init; }
        IReadOnlyList<IMustConstraint> MustConstraints { get; init; }
        IReadOnlyList<IMustNotConstraint> MustNotConstraints { get; init; }
    }
}
