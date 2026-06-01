namespace ContextCompiler.Abstractions.Pipelines.DataPart;

/// <summary>
/// Describes the technical transformation typically applied to a data part.
/// </summary>
public enum DataPartTransformationMode
{
    /// <summary>
    /// No transformation is recommended by default.
    /// </summary>
    None = 0,

    /// <summary>
    /// Partially conceal the value while keeping some operational readability.
    /// </summary>
    Mask = 1,

    /// <summary>
    /// Remove the sensitive portion from the payload.
    /// </summary>
    Redact = 2,

    /// <summary>
    /// Irreversibly derive a digest from the original value.
    /// </summary>
    Hash = 3,

    /// <summary>
    /// Protect the value with reversible cryptography.
    /// </summary>
    Encrypt = 4,

    /// <summary>
    /// Reduce the data to a summary that omits detailed raw content.
    /// </summary>
    Summarize = 5,
}
