namespace ContextCompiler.Prompting.Abstractions.Prompt
{
    public interface IGlossaryTerm
    {
        string Term { get; init; }
        string Definition { get; init; }
    }
}
