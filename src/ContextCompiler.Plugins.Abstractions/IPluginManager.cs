using ContextCompiler.Plugins.Abstractions.Configuration;

namespace ContextCompiler.Plugins.Abstractions
{
    public interface IPluginManager
    {
        IEnumerable<(string id, string version, string shaDir)> ListInstalled();
        PluginLockFile LoadLockFile();
        void PurgeCache(bool keepLockfilePinned = true);
        Task<PluginLockFile> RestoreAndLockAsync(CancellationToken ct);
        void SaveLockFile(PluginLockFile lockFile);
    }
}
