using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Framing
{
    internal sealed class Blueprint : IBlueprint
    {
        public required string Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required IReadOnlyList<IMustConstraint> MustConstraints { get; init; }
        public required IReadOnlyList<IMustNotConstraint> MustNotConstraints { get; init; }
        public required IReadOnlyList<IObjective> Objectives { get; init; }
        public required IReadOnlyList<IAssumption> Assumptions { get; init; }
        public required IReadOnlyList<IGlossaryTerm> Glossary { get; init; }
        public required IReadOnlyList<ICommand> Commands { get; init; }
        public required IReadOnlyList<IBlueprintStep> Steps { get; init; }
    }
}
