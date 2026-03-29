namespace ContextCompiler.Abstractions.Prompt;

public interface IAssumptionBuilder
{
    IAssumption Build();
    IAssumptionBuilder InitNew();
    IAssumptionBuilder WithName(string name);
    IAssumptionBuilder WithDescription(string description);
}
