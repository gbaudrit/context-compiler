namespace ContextCompiler.Skills.Abstractions.Configuration;

public sealed class SkillDeclarationsConfig
{
    public string Mode { get; set; } = "Prompt";
    public bool AllowRequired { get; set; } = true;
    public bool AllowRecommended { get; set; }
}
