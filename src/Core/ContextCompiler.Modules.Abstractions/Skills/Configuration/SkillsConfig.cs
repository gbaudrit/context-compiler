using ContextCompiler.Modules.Abstractions.Configuration;

namespace ContextCompiler.Modules.Abstractions.Skills.Configuration;

public sealed class SkillsConfig : ISkillsLoadConfig
{
    public string Mode { get; set; } = "Restore";
    public bool Offline { get; set; }
    public string LockFile { get; set; } = ".ctxc/ctxc.skills.lock.json";
    public SkillDeclarationsConfig Declarations { get; set; } = new();
    public SkillTrustConfig Trust { get; set; } = new();
    public ArtifactsValidationConfig Validation { get; set; } = new();
    public Dictionary<string, string> Items { get; set; } = [];
}



