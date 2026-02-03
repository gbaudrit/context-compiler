namespace ContextCompiler.Abstractions.Prompt
{
    public interface IObjective
    {
        string Name { get; init; }
        string Description { get; init; }
    }
}
