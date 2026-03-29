using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Tags
{
    public interface ITagBuilder
    {
        ITag Build(string name, string value);
    }
}
