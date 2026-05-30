namespace ContextCompiler.Abstractions.Output;

/// <summary>
/// Defines the category of an output artifact for classification and handling purposes.
/// </summary>
public enum ArtifactCategory
{
    /// <summary>
    /// Context files like prompt.context.md
    /// </summary>
    Context,

    /// <summary>
    /// Evidence files like evidence.index.json
    /// </summary>
    Evidence,

    /// <summary>
    /// Report files like security.report.md, health.report.md
    /// </summary>
    Report,

    /// <summary>
    /// Graph files like evidence.graph.json
    /// </summary>
    Graph,

    /// <summary>
    /// View files like view.{id}.md
    /// </summary>
    View,

    /// <summary>
    /// Skills to be deployed to .agents/skills
    /// </summary>
    Skill,

    /// <summary>
    /// MCP tools to be deployed to .agents/tools
    /// </summary>
    Tool,

    /// <summary>
    /// Configuration files generated during compilation
    /// </summary>
    Configuration,

    /// <summary>
    /// Other unclassified artifacts
    /// </summary>
    Other
}
