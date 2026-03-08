using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing
{
    internal sealed class CommandBuilder : ICommandBuilder
    {
        private string? _name;
        private string? _description;
        private string? _personaId;
        private List<ICommand>? _subs;

        public ICommandBuilder InitNew()
        {
            _name = null;
            _description = null;
            _subs = [];
            return this;
        }

        public ICommandBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ICommandBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public ICommandBuilder WithSubs(List<ICommand> subs)
        {
            _subs = subs;
            return this;
        }

        public ICommandBuilder ForPersona(string personaId)
        {
            _personaId = personaId;
            return this;
        }

        public ICommand Build()
        {
            return _name is null
                ? throw new InvalidOperationException("Command name is required.")
                : _description is null
                ? throw new InvalidOperationException("Command description is required.")
                : (ICommand)new Command() { Name = _name, Description = _description, Subs = _subs ?? [], PersonaId = _personaId ?? string.Empty };
        }
    }
}
