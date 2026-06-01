using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Core.Pipelines.InputIngestion;

public sealed record DataEnvelope(
    DataShape Shape
) : IDataEnvelope
{
    public IReadOnlyList<IDataPart> Parts { get; init; } = [];
    public IReadOnlyDictionary<string, string>? Metadata { get; init; } = new Dictionary<string, string>();
};
