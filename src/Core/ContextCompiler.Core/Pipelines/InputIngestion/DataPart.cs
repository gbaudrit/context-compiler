using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.DataPart;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Core.Pipelines.InputIngestion
{
    public sealed record DataPart(
        string PartId,
        ISourceRef Source,
        object Payload,
        DataPartType Type,
        string? Label = null,
        IReadOnlyList<ITag>? Tags = null,
        string? GroupId = null) : IDataPart;
}
