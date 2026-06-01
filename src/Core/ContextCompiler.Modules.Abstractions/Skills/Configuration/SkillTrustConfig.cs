namespace ContextCompiler.Modules.Abstractions.Skills.Configuration;

public sealed class SkillTrustConfig
{
    public bool RequireTrustedProvider { get; set; } = true;
    public List<string> AllowedProviders { get; set; } = [];
    public List<string> BlockedProviders { get; set; } = [];
    public List<string> BlockedSkills { get; set; } = [];
}
