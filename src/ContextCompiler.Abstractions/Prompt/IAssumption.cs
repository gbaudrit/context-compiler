namespace ContextCompiler.Abstractions.Prompt
{
    public interface IAssumption
    {
        string Name { get; init; }
        string Description { get; init; }
    }
}
