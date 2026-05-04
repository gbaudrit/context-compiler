namespace ContextCompiler.Prompting.Abstractions.Prompt
{
    public interface IAudience
    {
        string Name { get; init; }
        string Description { get; init; }
    }
}
