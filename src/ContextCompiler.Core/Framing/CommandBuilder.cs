using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing
{
    internal sealed class CommandBuilder : ICommandBuilder
    {
        private string? _name;
        private string? _description;
        private List<ICommand>? _subs;

        public ICommandBuilder InitNew()
        {
            _name = null;
            _description = null;
            _subs = new List<ICommand>();
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

        public ICommand Build()
        {
            if (_name is null) throw new InvalidOperationException("Command name is required.");
            if (_description is null) throw new InvalidOperationException("Command description is required.");
            return new Command() { Name = _name, Description = _description, Subs = _subs ?? [] };
        }
    }
}
