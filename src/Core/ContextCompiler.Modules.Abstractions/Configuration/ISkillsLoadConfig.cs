namespace ContextCompiler.Modules.Abstractions.Configuration;

public interface ISkillsLoadConfig
{
    string Mode { get; set; }
    bool Offline { get; set; }
    string CacheRoot { get; set; }
    string CompiledRoot { get; set; }
    string LockFile { get; set; }
    SkillDeclarationsConfig Declarations { get; set; }
    SkillTrustConfig Trust { get; set; }
    ArtifactsValidationConfig Validation { get; set; }
    Dictionary<string, string> Items { get; set; }
}
