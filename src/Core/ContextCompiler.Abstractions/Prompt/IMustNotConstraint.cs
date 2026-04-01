namespace ContextCompiler.Abstractions.Prompt
{
    public interface IMustNotConstraint
    {
        string Id { get; init; }
        string Rationale { get; init; }
        string Text { get; init; }
    }
}
