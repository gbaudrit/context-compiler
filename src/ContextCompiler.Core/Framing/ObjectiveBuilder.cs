using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing
{
    internal sealed class ObjectiveBuilder : IObjectiveBuilder
    {
        private string? _name;
        private string? _description;

        public IObjectiveBuilder InitNew()
        {
            _name = null;
            _description = null;
            return this;
        }

        public IObjectiveBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public IObjectiveBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public IObjective Build()
        {
            return _name is null
                ? throw new InvalidOperationException("Objective name is required.")
                : _description is null
                ? throw new InvalidOperationException("Objective description is required.")
                : (IObjective)new Objective() { Name = _name, Description = _description };
        }
    }
}
