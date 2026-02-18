namespace ContextCompiler.Plugins.Abstractions.Configuration;

public class PluginsConfig : IPluginsLoadConfig
{
    public string Mode { get; set; } = "Locked";
    public string InstallRoot { get; set; } = ".ctxc/plugins";
    public bool Offline { get; set; }
    public string LockFile { get; set; } = ".ctxc/ctxc.plugins.lock.json";
    public string QuarantineRoot { get; set; } = ".ctxc/quarantine";
    public List<PluginSource> Sources { get; set; } = [];
    public TrustConfig Trust { get; set; } = new();
    public List<PluginPackageRequest> Packages { get; set; } = [];
}

public sealed class PluginSource { public string Name { get; set; } = default!; public string Url { get; set; } = default!; public bool Trusted { get; set; } }
public sealed class TrustConfig
{
    public bool RequireTrustedSource { get; set; } = true;
    public bool RequireSignedPackages { get; set; } = true;
    public List<string> AllowedPackageIds { get; set; } = ["ContextCompiler.Plugins.*"];
    public List<string> BlockedPackageIds { get; set; } = [];
    public List<string> AllowedAuthors { get; set; } = [];
    public List<string> AllowedRepositoryPrefixes { get; set; } = [];
}
public sealed class PluginPackageRequest
{
    public string Id { get; set; } = default!;
    public string Version { get; set; } = default!;
    public string Source { get; set; } = default!;
    public string? Sha256 { get; set; }
    public string? MinPluginApiVersion { get; set; }
    public List<string> Capabilities { get; set; } = [];
}
public sealed class PluginLockFile
{
    public int FormatVersion { get; set; } = 1;
    public DateTime GeneratedAt { get; set; } = DateTime.UnixEpoch;
    public List<LockedPlugin> Packages { get; set; } = [];
    public sealed class LockedPlugin
    {
        public string Id { get; set; } = default!;
        public string Version { get; set; } = default!;
        public string Source { get; set; } = default!;
        public string Sha256 { get; set; } = default!;
        public NuspecInfo Nuspec { get; set; } = new();
        public SignatureInfo Signature { get; set; } = new();
        public List<DependencyInfo> Dependencies { get; set; } = [];
        public List<string> Files { get; set; } = [];
    }
    public sealed class NuspecInfo { public string Authors { get; set; } = ""; public string? RepositoryUrl { get; set; } }
    public sealed class SignatureInfo { public bool Required { get; set; } public bool IsSigned { get; set; } public string? SignerFingerprint { get; set; } public string? Note { get; set; } }
    public sealed class DependencyInfo { public string Id { get; set; } = default!; public string Version { get; set; } = default!; }
}
