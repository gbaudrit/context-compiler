using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.DataPart;

namespace ContextCompiler.Abstractions.Pipelines.InputIngestion
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
        IDataPartBuilder WithType(DataPartType type);
        IDataPartBuilder WithGroupId(string? groupId);
    }
}
