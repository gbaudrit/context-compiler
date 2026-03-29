using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Pipelines.Document;

public sealed record DataEnvelope(
    DataShape Shape
) : IDataEnvelope
{
    public IReadOnlyList<IDataPart> Parts { get; init; } = [];
    public IReadOnlyDictionary<string, string>? Metadata { get; init; } = new Dictionary<string, string>();
};
