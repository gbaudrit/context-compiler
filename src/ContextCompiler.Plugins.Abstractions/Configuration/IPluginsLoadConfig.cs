namespace ContextCompiler.Plugins.Abstractions.Configuration;

public interface IPluginsLoadConfig
{
    string InstallRoot { get; set; }
    string LockFile { get; set; }
    string Mode { get; set; }
    bool Offline { get; set; }
    List<PluginPackageRequest> Packages { get; set; }
    string QuarantineRoot { get; set; }
    List<PluginSource> Sources { get; set; }
    TrustConfig Trust { get; set; }
    string ConfigurationModule { get; set; }
}
