namespace ContextCompiler.Abstractions.Models;

public enum DataShape
{
    Linear,
    Tabular,
    Hierarchical,
    KeyBased,
    Composite
}

public sealed record DataEnvelope(
    DataShape Shape,
    object Payload,
    IReadOnlyDictionary<string, string>? Metadata = null
);
