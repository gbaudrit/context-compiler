using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Framing
{
    internal sealed class MustConstraint : IMustConstraint
    {
        public required string Id { get; init; }
        public required string Rationale { get; init; }
        public required string Text { get; init; }
    }
}
