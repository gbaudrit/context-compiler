namespace ContextCompiler.Abstractions.Prompt
{
    public interface IAssumption
    {
        string Id { get; init; }
        string Name { get; init; }
        string Description { get; init; }
        string Rationale { get; init; }
    }
}
