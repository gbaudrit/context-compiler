
using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing
{
    internal sealed class Command : ICommand
    {
        public required string Id { get; init; }
        public required string Description { get; init; }
        public string Example { get; init; } = string.Empty;
        public List<ICommand> Subs { get; init; } = [];
        public string PersonaId { get; init; } = string.Empty;
    }
}
