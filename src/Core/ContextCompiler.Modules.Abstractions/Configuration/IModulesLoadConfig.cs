namespace ContextCompiler.Modules.Abstractions.Configuration;

public interface IModulesLoadConfig
{
    string InstallRoot { get; set; }
    string LockFile { get; set; }
    string RunModulesFile { get; set; }
    string Mode { get; set; }
    bool Offline { get; set; }
    Dictionary<string, string> Packages { get; set; }
    string QuarantineRoot { get; set; }
    List<ModuleSource> Sources { get; set; }
    TrustConfig Trust { get; set; }
    string ConfigurationModule { get; set; }
}
