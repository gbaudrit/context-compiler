using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Framing
{
    internal sealed class Audience : IAudience
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
    }
}
