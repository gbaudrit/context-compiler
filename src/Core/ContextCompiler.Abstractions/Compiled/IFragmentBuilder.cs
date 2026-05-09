using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Abstractions.Compiled
{
    public interface IFragmentBuilder
    {
        IFragment Build();
        IFragmentBuilder InitNew();
        IFragmentBuilder WithFilePath(string filePath);
        IFragmentBuilder WithLocator(string locator);
        IFragmentBuilder WithTags(IReadOnlyList<ITag> tags);
        IFragmentBuilder WithContent(string content);
        IFragmentBuilder ForDataPart(IDataPart datapart);
    }
}
