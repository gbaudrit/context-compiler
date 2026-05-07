namespace ContextCompiler.Abstractions.Pipelines.InputIngestion;

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
    IReadOnlyDictionary<string, string>? Metadata { get; }
    IReadOnlyList<IDataPart> Parts { get; }
}
