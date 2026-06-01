using ContextCompiler.Modules.Abstractions.Configuration;

namespace ContextCompiler.Modules.Abstractions.Skills.Configuration;

public interface ISkillsLoadConfig
{
    string Mode { get; set; }
    bool Offline { get; set; }
    string LockFile { get; set; }
    SkillDeclarationsConfig Declarations { get; set; }
    SkillTrustConfig Trust { get; set; }
    ArtifactsValidationConfig Validation { get; set; }
    Dictionary<string, string> Items { get; set; }
}
