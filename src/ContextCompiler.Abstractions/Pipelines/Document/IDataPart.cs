using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IDataPart
    {
        string PartId { get; }
        ISourceRef Source { get; }
        string? Label { get; }
        object Payload { get; }
        IReadOnlyList<ITag>? Tags { get; }
    }
}
