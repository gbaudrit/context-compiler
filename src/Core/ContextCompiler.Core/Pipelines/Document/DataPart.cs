using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Core.Pipelines.Document
{
    public sealed record DataPart(string PartId,
                                  ISourceRef Source,
                                  object Payload,
                                  string? Label = null,
                                  IReadOnlyList<ITag>? Tags = null) : IDataPart;

}
