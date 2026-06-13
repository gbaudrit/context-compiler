namespace ContextCompiler.Modules.Abstractions.Configuration;

public class ModulesConfig : IModulesLoadConfig
{
    public const string ScopePrepare = "prepare";
    public const string ScopeCompile = "compile";
    public const string ScopeAll = "all";

    public string ActiveScope { get; set; } = ScopeAll;
    public string Mode { get; set; } = "Locked";
    public string InstallRoot { get; set; } = "modules";
    public bool Offline { get; set; }
    public string LockFile { get; set; } = "ctxc.modules.lock.json";
    public string RunModulesFile { get; set; } = "ctxc.modules.run.json";
    public string QuarantineRoot { get; set; } = "quarantine";
    public string ConfigurationModule { get; set; } = "ContextCompiler.Configuration.Json";
    public List<ModuleSource> Sources { get; set; } = [];
    public TrustConfig Trust { get; set; } = new();
    public Dictionary<string, string> Packages { get; set; } = [];
    public ModuleScopeConfig Prepare { get; set; } = new();
    public ModuleScopeConfig Compile { get; set; } = new();

    public Dictionary<string, string> GetPackagesForScope(string? scope)
    {
#pragma warning disable IDE0028, IDE0090
        Dictionary<string, string> scoped = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
#pragma warning restore IDE0028, IDE0090
        string normalized = string.IsNullOrWhiteSpace(scope) ? ScopeAll : scope;

        if (string.Equals(normalized, ScopePrepare, StringComparison.OrdinalIgnoreCase)
            || string.Equals(normalized, ScopeAll, StringComparison.OrdinalIgnoreCase))
        {
            AddRange(scoped, Prepare.Packages);
        }

        if (string.Equals(normalized, ScopeCompile, StringComparison.OrdinalIgnoreCase)
            || string.Equals(normalized, ScopeAll, StringComparison.OrdinalIgnoreCase))
        {
            AddRange(scoped, Compile.Packages);
        }

        if (string.Equals(normalized, ScopeAll, StringComparison.OrdinalIgnoreCase))
        {
            AddRange(scoped, Packages);
        }

        return scoped;
    }

    private static void AddRange(Dictionary<string, string> target, IReadOnlyDictionary<string, string> source)
    {
        foreach (KeyValuePair<string, string> entry in source)
        {
            target[entry.Key] = entry.Value;
        }
    }
}

public sealed class ModuleScopeConfig
{
    public Dictionary<string, string> Packages { get; set; } = [];
}

public sealed class ModuleSource
{
    public string Name { get; set; } = default!;
    public string Url { get; set; } = default!;
    public bool Trusted { get; set; }
    public string Provider { get; set; } = "nuget";
    public bool ValidatePackagesSignature { get; set; } = true;
}

public sealed class ModuleVersionOverridesConfig
{
    public int SchemaVersion { get; set; } = 1;
    public Dictionary<string, string> Overrides { get; set; } = [];
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


