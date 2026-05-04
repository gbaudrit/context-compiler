namespace ContextCompiler.Prompting.Abstractions.Prompt
{
    public interface IObjectiveBuilder
    {
        IObjective Build();
        IObjectiveBuilder InitNew();
        IObjectiveBuilder WithId(string id);
        IObjectiveBuilder WithDescription(string description);
        IObjectiveBuilder WithRationale(string rationale);
        IObjectiveBuilder WithName(string name);
    }
}
