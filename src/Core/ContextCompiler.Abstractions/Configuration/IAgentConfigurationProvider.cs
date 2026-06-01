namespace ContextCompiler.Abstractions.Configuration;

/// <summary>
/// Provides configuration settings specific to an agent type (e.g., Copilot, Claude, etc.).
/// </summary>
public interface IAgentConfigurationProvider
{
    /// <summary>
    /// Gets the current agent configuration.
    /// </summary>
    AgentConfiguration Configuration { get; }

    /// <summary>
    /// Gets the type of agent this provider configures.
    /// </summary>
    string AgentType { get; }
}
