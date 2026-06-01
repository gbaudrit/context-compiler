using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Framing;

internal sealed class AssumptionBuilder : IAssumptionBuilder
{
    private string? _id;
    private string? _name;
    private string? _description;
    private string? _rationale;

    public IAssumptionBuilder InitNew()
    {
        _id = null;
        _name = null;
        _description = null;
        _rationale = null;
        return this;
    }

    public IAssumptionBuilder WithId(string id)
    {
        _id = id;
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

    public IAssumptionBuilder WithRationale(string rationale)
    {
        _rationale = rationale;
        return this;
    }

    public IAssumption Build()
    {
        return _description is null
            ? throw new InvalidOperationException("Assumption description is required.")
            : (IAssumption)new Assumption
            {
                Id = _id ?? string.Empty,
                Name = _name ?? string.Empty,
                Description = _description,
                Rationale = _rationale ?? string.Empty
            };
    }
}
