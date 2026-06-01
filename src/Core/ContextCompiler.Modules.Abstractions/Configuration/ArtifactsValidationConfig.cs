namespace ContextCompiler.Modules.Abstractions.Configuration;


public sealed class ArtifactsValidationConfig
{
    public bool Enabled { get; set; } = true;
    public bool FailOnCritical { get; set; } = true;
    public bool SkipOnWarning { get; set; }
    public PrerequisitesValidationConfig Prerequisites { get; set; } = new();
    public SecurityValidationConfig Security { get; set; } = new();
    public DeploymentConfig Deployment { get; set; } = new();
}

