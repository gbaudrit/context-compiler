using ContextCompiler.Abstractions.Pipelines.DataPart;

namespace ContextCompiler.Modules.Security.Guards.DataPart;

/// <summary>
/// Configuration for DataPart guard module filtering rules.
/// </summary>
public sealed class DataPartGuardConfig
{
    /// <summary>
    /// Gets or sets the list of DataPartType values to exclude from context.
    /// </summary>
    public HashSet<DataPartType> ExcludedTypes { get; set; } = [];

    /// <summary>
    /// Gets or sets the list of categories to exclude.
    /// </summary>
    public HashSet<string> ExcludedCategories { get; set; } = [];

    /// <summary>
    /// Gets or sets the minimum agent context action required for inclusion.
    /// Parts with actions below this level will be excluded.
    /// </summary>
    public DataPartAgentContextAction? MinimumAgentContextAction { get; set; }

    /// <summary>
    /// Gets or sets traits that should result in exclusion.
    /// </summary>
    public DataPartTraits ExcludedTraits { get; set; } = DataPartTraits.None;

    /// <summary>
    /// Gets or sets whether to exclude all personal data (shortcut for PersonalData trait).
    /// </summary>
    public bool ExcludePersonalData { get; set; } = true;

    /// <summary>
    /// Gets or sets whether to exclude sensitive data (shortcut for Sensitive trait).
    /// </summary>
    public bool ExcludeSensitiveData { get; set; } = true;
}
