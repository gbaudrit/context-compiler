namespace ContextCompiler.Abstractions.ReasoningIR
{
    public interface ITranscodedFragment
    {
        string Locator { get; }
        string Content { get; }
        IReadOnlyList<ITag> Tags { get; }
    }
}
