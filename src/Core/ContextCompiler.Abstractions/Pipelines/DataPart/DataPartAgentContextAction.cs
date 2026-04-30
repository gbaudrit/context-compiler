namespace ContextCompiler.Abstractions.Pipelines.DataPart;

/// <summary>
/// Describes the default way an AI-agent pipeline should use a data part when
/// building model context.
/// </summary>
public enum DataPartAgentContextAction
{
    /// <summary>
    /// No default agent-context decision has been defined.
    /// </summary>
    None = 0,

    /// <summary>
    /// The data can usually be included in agent context.
    /// </summary>
    Include = 1,

    /// <summary>
    /// The data should be reduced to a less identifying or less detailed summary.
    /// </summary>
    Summarize = 2,

    /// <summary>
    /// The data should stay out of agent context by default.
    /// </summary>
    Excluded = 3,

    /// <summary>
    /// The data requires an explicit purpose-specific decision before inclusion.
    /// </summary>
    RequireExplicitApproval = 4,
}
