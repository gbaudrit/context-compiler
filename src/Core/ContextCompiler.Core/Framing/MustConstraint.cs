using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing
{
    internal sealed class MustConstraint : IMustConstraint
    {

        public required string Id { get; init; }
        public required string Text { get; init; }

    }
}
