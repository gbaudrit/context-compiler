namespace ContextCompiler.Abstractions.Prompt
{
    public interface IMustConstraint
    {
        string Text { get; init; }
        string Id { get; init; }
    }
}
