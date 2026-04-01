using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing
{
    internal sealed class ObjectiveBuilder : IObjectiveBuilder
    {
        private string? _id;
        private string? _name;
        private string? _description;
        private string? _rationale;

        public IObjectiveBuilder InitNew()
        {
            _id = null;
            _name = null;
            _description = null;
            _rationale = null;
            return this;
        }

        public IObjectiveBuilder WithId(string id)
        {
            _id = id;
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

        public IObjectiveBuilder WithRationale(string rationale)
        {
            _rationale = rationale;
            return this;
        }

        public IObjective Build()
        {
            return _description is null
                ? throw new InvalidOperationException("Objective description is required.")
                : (IObjective)new Objective()
                {
                    Id = _id ?? string.Empty,
                    Name = _name ?? string.Empty,
                    Description = _description,
                    Rationale = _rationale ?? string.Empty
                };
        }
    }
}
