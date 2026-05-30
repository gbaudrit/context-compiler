using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Agents.Modules.Copilot;

/// <summary>
/// Provides configuration for GitHub Copilot agent.
/// </summary>
public sealed class CopilotAgentConfigurationProvider : IAgentConfigurationProvider
{
    /// <inheritdoc />
    public AgentConfiguration Configuration { get; }

    /// <inheritdoc />
    public string AgentType => "copilot";

    /// <summary>
    /// Creates a provider with default Copilot configuration.
    /// </summary>
    public CopilotAgentConfigurationProvider()
    {
        Configuration = AgentConfiguration.ForCopilot();
    }

    /// <summary>
    /// Creates a provider with a custom skills output path.
    /// </summary>
    /// <param name="skillsOutputPath">Custom path for skills output.</param>
    public CopilotAgentConfigurationProvider(string skillsOutputPath)
    {
        Configuration = AgentConfiguration.ForCopilot()
            .WithSkillsOutputPath(skillsOutputPath);
    }

    /// <summary>
    /// Creates a provider with a custom configuration.
    /// </summary>
    /// <param name="configuration">Custom agent configuration.</param>
    public CopilotAgentConfigurationProvider(AgentConfiguration configuration)
    {
        Configuration = configuration with { AgentType = "copilot" };
    }
}
