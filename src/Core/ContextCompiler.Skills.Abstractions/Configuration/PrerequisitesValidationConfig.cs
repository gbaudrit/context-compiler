namespace ContextCompiler.Skills.Abstractions.Configuration;

public sealed class PrerequisitesValidationConfig
{
    public bool Enabled { get; set; } = true;
    public List<string> RequiredTools { get; set; } = ["docker", "git"];
    public Dictionary<string, string> MinVersions { get; set; } = new()
    {
        ["docker"] = "20.0.0",
        ["git"] = "2.0.0"
    };
}
