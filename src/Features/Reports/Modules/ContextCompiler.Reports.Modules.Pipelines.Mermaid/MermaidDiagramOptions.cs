namespace ContextCompiler.Reports.Modules.Pipelines.Mermaid;

/// <summary>
/// Configuration options for Mermaid diagram generation.
/// </summary>
public sealed class MermaidDiagramOptions
{
    /// <summary>
    /// Gets or sets the maximum text size allowed in the Mermaid diagram.
    /// Default is 200000 characters.
    /// </summary>
    public int MaxTextSize { get; set; } = 200000;

    /// <summary>
    /// Gets or sets the maximum number of edges in the diagram.
    /// Default is 2000.
    /// </summary>
    public int MaxEdges { get; set; } = 2000;

    /// <summary>
    /// Gets or sets the detail level for the diagram.
    /// Default is Detailed to show all events including items.
    /// </summary>
    public DiagramDetailLevel DetailLevel { get; set; } = DiagramDetailLevel.Detailed;

    /// <summary>
    /// Gets or sets whether to show module details in phase nodes.
    /// Default is true.
    /// </summary>
    public bool ShowModuleDetails { get; set; } = true;

    /// <summary>
    /// Gets or sets whether to show duration information in phase nodes.
    /// Default is true.
    /// </summary>
    public bool ShowDuration { get; set; } = true;

    /// <summary>
    /// Gets or sets whether to show item IDs in the diagram.
    /// Default is true.
    /// </summary>
    public bool ShowItemIds { get; set; } = true;
}

/// <summary>
/// Defines the level of detail for the diagram.
/// </summary>
public enum DiagramDetailLevel
{
    /// <summary>
    /// Groups all events by phase, showing only phase-level information.
    /// Most compact view.
    /// </summary>
    Condensed = 0,

    /// <summary>
    /// Shows individual events with module and item information.
    /// Full detail view.
    /// </summary>
    Detailed = 1
}
