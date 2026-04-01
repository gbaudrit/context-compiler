namespace ContextCompiler.Abstractions.Prompt
{
    public interface IBlueprint
    {
        string Id { get; init; }
        string Name { get; init; }
        string Description { get; init; }
        IReadOnlyList<IMustConstraint> MustConstraints { get; init; }
        IReadOnlyList<IMustNotConstraint> MustNotConstraints { get; init; }
        IReadOnlyList<IObjective> Objectives { get; init; }
        IReadOnlyList<IAssumption> Assumptions { get; init; }
        IReadOnlyList<IGlossaryTerm> Glossary { get; init; }
        IReadOnlyList<ICommand> Commands { get; init; }
        IReadOnlyList<IBlueprintStep> Steps { get; init; }
    }
}
