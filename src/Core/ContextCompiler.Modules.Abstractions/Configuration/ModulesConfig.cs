namespace ContextCompiler.Modules.Abstractions.Configuration;

public class ModulesConfig : IModulesLoadConfig
{
    public string Mode { get; set; } = "Locked";
    public string InstallRoot { get; set; } = ".ctxc/modules";
    public bool Offline { get; set; }
    public string LockFile { get; set; } = ".ctxc/ctxc.modules.lock.json";
    public string RunModulesFile { get; set; } = ".ctxc/ctxc.modules.run.json";
    public string QuarantineRoot { get; set; } = ".ctxc/quarantine";
    public string ConfigurationModule { get; set; } = "ContextCompiler.Configuration.Json";
    public List<ModuleSource> Sources { get; set; } = [];
    public TrustConfig Trust { get; set; } = new();
    public Dictionary<string, string> Packages { get; set; } = [];
}

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

public sealed class DeploymentConfig
{
    public string TargetPath { get; set; } = ".agents/skills";
    public bool OverwriteExisting { get; set; } = true;
    public bool GenerateReport { get; set; } = true;
    public string ReportPath { get; set; } = "artifacts.deployment.report.md";
}

public sealed class ModuleSource
{
    public string Name { get; set; } = default!;
    public string Url { get; set; } = default!;
    public bool Trusted { get; set; }
    public string Provider { get; set; } = "nuget";
}


public sealed class TrustConfig
{
    public bool RequireTrustedSource { get; set; } = true;
    public bool RequireSignedPackages { get; set; } = true;
    public List<string> AllowedPackageIds { get; set; } = ["ContextCompiler.Modules.*"];
    public List<string> BlockedPackageIds { get; set; } = [];
    public List<string> AllowedAuthors { get; set; } = [];
    public List<string> AllowedRepositoryPrefixes { get; set; } = [];
}
//public sealed class ModulePackageRequest
//{
//    public string Id { get; set; } = default!;
//    public string Version { get; set; } = default!;
//    public string Source { get; set; } = default!;
//    public string? Sha256 { get; set; }
//    public string? MinModuleApiVersion { get; set; }
//}
public sealed class ModuleLockFile
{
    public int FormatVersion { get; set; } = 1;
    public DateTime GeneratedAt { get; set; } = DateTime.UnixEpoch;
    public List<LockedModule> Packages { get; set; } = [];
    public sealed class LockedModule
    {
        public string Id { get; set; } = default!;
        public Version Version { get; set; } = default!;
        public string Source { get; set; } = default!;
        public string Checksum { get; set; } = default!;

        public SignatureInfo Signature { get; set; } = new();
        public List<DependencyInfo> Dependencies { get; set; } = [];
        public List<string> Files { get; set; } = [];
        public string[] Authors { get; set; } = [];
        public string? RepositoryUrl { get; set; }
    }

    public sealed class Version
    {
        public string Raw { get; set; } = "";
        public string Min { get; set; } = "";
        public string Max { get; set; } = "";
        public BoundOperator MinBoundOperator { get; set; } = BoundOperator.Exactly;
        public BoundOperator MaxBoundOperator { get; set; } = BoundOperator.Exactly;
    }

    public enum BoundOperator
    {
        Exactly,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
        Unbounded
    }

    public sealed class SignatureInfo { public bool Required { get; set; } public bool IsSigned { get; set; } public string? SignerFingerprint { get; set; } public string? Note { get; set; } }
    public sealed class DependencyInfo { public string Id { get; set; } = default!; public string Version { get; set; } = default!; }
}


