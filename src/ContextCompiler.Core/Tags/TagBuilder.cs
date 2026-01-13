using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Core.ReasoningIR;

namespace ContextCompiler.Core.Tags;

internal sealed class TagBuilder : ITagBuilder
{

    public ITag Build(string name, string value)
    {
        return new Tag(name, value);
    }

    

}
