namespace ContextCompiler.Skills.Abstractions.Configuration;

public sealed class DeploymentConfig
{
    public string TargetPath { get; set; } = ".agents/skills";
    public bool OverwriteExisting { get; set; } = true;
    public bool GenerateReport { get; set; } = true;
    public string ReportPath { get; set; } = "artifacts.deployment.report.md";
}
