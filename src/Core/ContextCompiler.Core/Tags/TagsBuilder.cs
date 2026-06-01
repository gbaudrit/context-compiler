using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Tags;

namespace ContextCompiler.Core.Tags;

internal sealed class TagsBuilder(ITagBuilder tagBuilder) : ITagsBuilder
{
    private List<ITag> _tags = [];

    public ITagsBuilder Add(string name, string value)
    {
        _tags.Add(tagBuilder.Build(name, value));
        return this;
    }

    public ITagsBuilder AddRange(string[] toAdd)
    {
        foreach (string item in toAdd)
        {
            string name = item.Split(":", 2)[0];
            string value = item.Split(":", 2)[1];
            _tags.Add(tagBuilder.Build(name, value));
        }
        return this;
    }

    public ITagsBuilder AddRange(IReadOnlyList<ITag>? toAdd)
    {
        if (toAdd is null)
        {
            return this;
        }

        _tags.AddRange([.. toAdd]);
        return this;
    }

    public IReadOnlyList<ITag> Build()
    {
        return _tags.AsReadOnly();
    }

    public ITagsBuilder InitNew()
    {
        _tags = [];
        return this;
    }

    public ITagsBuilder InitNewFrom(IReadOnlyList<ITag>? tags)
    {
        _tags = tags?.ToList() ?? [];
        return this;
    }
}
