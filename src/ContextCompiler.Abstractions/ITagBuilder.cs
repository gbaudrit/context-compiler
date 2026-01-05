using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions
{
    public interface ITagBuilder
    {
        IList<ITag> AddRange(IList<ITag> tags, string[] toAdd);
        IList<ITag> AddRange(IList<ITag> tags, IList<ITag> toAdd);
        ITag Build(string name, string value);
        IList<ITag> Build(string[] tags);
        IList<ITag> Build(IDictionary<string, string> tags);
    }
}
