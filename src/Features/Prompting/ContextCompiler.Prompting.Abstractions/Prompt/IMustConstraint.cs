namespace ContextCompiler.Prompting.Abstractions.Prompt
{
    public interface IMustConstraint
    {
        string Id { get; init; }
        string Rationale { get; init; }
        string Text { get; init; }
    }
}
