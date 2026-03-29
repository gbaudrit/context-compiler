namespace ContextCompiler.Abstractions.Prompt;

public interface IAudienceBuilder
{
    IAudience Build();
    IAudienceBuilder InitNew();
    IAudienceBuilder WithName(string name);
    IAudienceBuilder WithDescription(string description);
}
