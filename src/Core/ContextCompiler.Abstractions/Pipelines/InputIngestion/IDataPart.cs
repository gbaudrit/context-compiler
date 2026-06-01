using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.DataPart;

namespace ContextCompiler.Abstractions.Pipelines.InputIngestion
{
    public interface IDataPart
    {
        string PartId { get; }
        ISourceRef Source { get; }
        string? Label { get; }
        object Payload { get; }
        IReadOnlyList<ITag>? Tags { get; }
        DataPartType Type { get; }
        string? GroupId { get; }
    }
}
