using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing;

internal sealed class AssumptionBuilder : IAssumptionBuilder
{
    private string? _name;
    private string? _description;

    public IAssumptionBuilder InitNew()
    {
        _name = null;
        _description = null;
        return this;
    }

    public IAssumptionBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IAssumptionBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public IAssumption Build()
    {
        return _name is null
            ? throw new InvalidOperationException("Assumption name is required.")
            : _description is null
            ? throw new InvalidOperationException("Assumption description is required.")
            : (IAssumption)new Assumption { Name = _name, Description = _description };
    }
}
