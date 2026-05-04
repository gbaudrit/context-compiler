using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Framing
{
    internal sealed class GlossaryTerm : IGlossaryTerm
    {

        public required string Term { get; init; }
        public required string Definition { get; init; }

    }
}
