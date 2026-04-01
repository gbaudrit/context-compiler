namespace ContextCompiler.Abstractions.Prompt
{
    public interface IObjective
    {
        string Id { get; init; }
        string Name { get; init; }
        string Description { get; init; }
        string Rationale { get; init; }
    }
}
