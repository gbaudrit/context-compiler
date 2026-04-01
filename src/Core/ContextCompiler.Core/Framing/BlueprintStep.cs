using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing
{
    internal sealed class BlueprintStep : IBlueprintStep
    {
        public required string Content { get; init; }
        public required IReadOnlyList<IMustConstraint> MustConstraints { get; init; }
        public required IReadOnlyList<IMustNotConstraint> MustNotConstraints { get; init; }
    }
}
