using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Models;

public sealed record CompositeDataEnvelope(IReadOnlyList<DataPart> Parts);

public sealed record DataPart(
    string PartId,
    SourceRef Source,
    DataEnvelope Envelope,
    string? Label = null
);
