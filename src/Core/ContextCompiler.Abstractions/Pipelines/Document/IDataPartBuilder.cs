using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IDataPartBuilder
    {
        IDataPart Build();
        IDataPartBuilder InitNew();
        IDataPartBuilder WithId(string id);
        IDataPartBuilder WithLabel(string? label);
        IDataPartBuilder WithPayload(object? payload);
        IDataPartBuilder WithSource(ISourceRef source);
        IDataPartBuilder WithTags(IReadOnlyList<ITag> tags);
    }
}
