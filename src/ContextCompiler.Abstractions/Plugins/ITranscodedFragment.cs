using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Plugins
{
    public interface ITranscodedFragment
    {
        string Locator { get; }
        string Content { get; }
        IReadOnlyList<ITag> Tags { get; }
    }
}
