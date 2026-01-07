namespace ContextCompiler.Abstractions.Pipelines.Document;

public enum DataShape
{
    Linear,
    Tabular,
    Hierarchical,
    KeyBased,
    Composite
}

public interface IDataEnvelope
{
    DataShape Shape { get; }
    object Payload { get; }
    IReadOnlyDictionary<string, string>? Metadata { get; }
    IReadOnlyList<IDataPart> Parts { get; }
}
