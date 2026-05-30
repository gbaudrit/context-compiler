namespace ContextCompiler.Abstractions.Configuration;

/// <summary>
/// Configuration settings for an agent type.
/// </summary>
public sealed record AgentConfiguration
{
    /// <summary>
    /// Gets or initializes the output path for skills relative to the workspace root.
    /// Default is ".agents/skills".
    /// </summary>
    public string SkillsOutputPath { get; init; } = ".agents/skills";

    /// <summary>
    /// Gets or initializes the agent type identifier (e.g., "copilot", "claude").
    /// </summary>
    public string AgentType { get; init; } = "default";

    /// <summary>
    /// Gets or initializes additional agent-specific metadata.
    /// This allows for future extensibility without breaking changes.
    /// </summary>
    public Dictionary<string, object> Metadata { get; init; } = [];

    /// <summary>
    /// Creates a default configuration.
    /// </summary>
    public static AgentConfiguration Default => new();

    /// <summary>
    /// Creates a configuration for Copilot agent.
    /// </summary>
    public static AgentConfiguration ForCopilot()
    {
        return new()
        {
            AgentType = "copilot",
            SkillsOutputPath = ".agents/skills"
        };
    }

    /// <summary>
    /// Creates a configuration with a custom skills output path.
    /// </summary>
    public AgentConfiguration WithSkillsOutputPath(string path)
    {
        return this with { SkillsOutputPath = path };
    }

    /// <summary>
    /// Adds or updates metadata.
    /// </summary>
    public AgentConfiguration WithMetadata(string key, object value)
    {
        Dictionary<string, object> newMetadata = new(Metadata) { [key] = value };
        return this with { Metadata = newMetadata };
    }
}
