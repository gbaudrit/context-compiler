using ContextCompiler.Abstractions.Prompt;

namespace ContextCompiler.Core.Framing;

internal sealed class AudienceBuilder : IAudienceBuilder
{
    private string? _name;
    private string? _description;

    public IAudienceBuilder InitNew()
    {
        _name = null;
        _description = null;
        return this;
    }

    public IAudienceBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IAudienceBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public IAudience Build()
    {
        return _name is null
            ? throw new InvalidOperationException("Audience name is required.")
            : _description is null
            ? throw new InvalidOperationException("Audience description is required.")
            : (IAudience)new Audience { Name = _name, Description = _description };
    }
}
