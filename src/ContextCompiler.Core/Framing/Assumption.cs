using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing
{
    internal sealed class Assumption : IAssumption
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
   }
}
