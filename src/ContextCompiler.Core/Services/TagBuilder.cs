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

        public IList<ITag> Build(IDictionary<string, string> tags)
        {
            var list = new List<ITag>();
            foreach (var kvp in tags)
            {
                list.Add(new Tag(kvp.Key, kvp.Value));
            }
            return list;
        }

        public IList<ITag> Build(string[] tags)
        {
            var list = new List<ITag>();
            foreach (var tag in tags)
            {
                string name = tag.Split(":", 2)[0];
                string value = tag.Split(":", 2)[1];
                list.Add(new Tag(name, value));
            }
            return list;
        }

        public IList<ITag> AddRange(IList<ITag> tags, string[] toAdd)
        {
            tags = tags.Concat(Build(toAdd)).ToList();
            return tags;
        }

        public IList<ITag> AddRange(IList<ITag> tags, IList<ITag> toAdd)
        {
            tags = tags.Concat(toAdd).ToList();
            return tags;
        }

    }
}
