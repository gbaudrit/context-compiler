namespace ContextCompiler.Abstractions.Prompt
{
    public interface IMustNotConstraint
    {
        string Text { get; init; }
        string Id { get; init; }
    }
}
