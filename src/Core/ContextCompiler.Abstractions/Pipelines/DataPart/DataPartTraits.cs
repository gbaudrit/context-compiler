namespace ContextCompiler.Abstractions.Pipelines.DataPart;

/// <summary>
/// Flags describing stable cross-cutting characteristics of a data part.
/// </summary>
[Flags]
public enum DataPartTraits
{
    /// <summary>
    /// No trait is specified.
    /// </summary>
    None = 0,

    /// <summary>
    /// Generic non-domain-specific content.
    /// </summary>
    GenericContent = 1 << 0,

    /// <summary>
    /// Structured or machine-readable content.
    /// </summary>
    Structured = 1 << 1,

    /// <summary>
    /// Personal data.
    /// </summary>
    PersonalData = 1 << 2,

    /// <summary>
    /// Sensitive data requiring elevated handling.
    /// </summary>
    Sensitive = 1 << 3,

    /// <summary>
    /// Secret or credential-like data.
    /// </summary>
    Secret = 1 << 4,

    /// <summary>
    /// Financial data.
    /// </summary>
    Financial = 1 << 5,

    /// <summary>
    /// Official or government-backed identifier data.
    /// </summary>
    OfficialIdentifier = 1 << 6,

    /// <summary>
    /// Business-sensitive data.
    /// </summary>
    BusinessSensitive = 1 << 7,

    /// <summary>
    /// AI- or prompt-sensitive data.
    /// </summary>
    AiSensitive = 1 << 8,

    /// <summary>
    /// A transformation can usually be applied safely in a pipeline.
    /// </summary>
    Transformable = 1 << 9,

    /// <summary>
    /// Prefer reversible controls such as encryption or tokenization over destructive rewriting.
    /// </summary>
    ReversibleTransformationPreferred = 1 << 10,

    /// <summary>
    /// The data should generally stay out of LLM inputs.
    /// </summary>
    ExcludeFromLlmInput = 1 << 11,

    /// <summary>
    /// The data should be encrypted at rest by default.
    /// </summary>
    RequiresEncryptionAtRest = 1 << 12,
}
