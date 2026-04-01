namespace ContextCompiler.Abstractions.Prompt;

public interface IAssumptionBuilder
{
    IAssumption Build();
    IAssumptionBuilder InitNew();
    IAssumptionBuilder WithId(string id);
    IAssumptionBuilder WithName(string name);
    IAssumptionBuilder WithDescription(string description);
    IAssumptionBuilder WithRationale(string rationale);
}
