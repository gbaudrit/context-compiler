using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Core.ReasoningIR;

namespace ContextCompiler.Core.Services
{
    internal sealed class TagBuilder : ITagBuilder
    {

        public ITag Build(string name, string value)
        {
            return new Tag(name, value);
        }

        

    }
}
