using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Tags
{
    public interface ITagsBuilder
    {
        ITagsBuilder InitNew();
        ITagsBuilder InitNewFrom(IReadOnlyList<ITag>? tags);
        ITagsBuilder AddRange(string[] toAdd);
        ITagsBuilder Add(string name, string value);
        IReadOnlyList<ITag> Build();
        ITagsBuilder AddRange(IReadOnlyList<ITag>? toAdd);
    }
}
