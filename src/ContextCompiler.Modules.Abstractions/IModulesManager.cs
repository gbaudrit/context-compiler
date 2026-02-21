using ContextCompiler.Modules.Abstractions.Configuration;

namespace ContextCompiler.Modules.Abstractions
{
    public interface IModulesManager
    {
        IEnumerable<(string id, string version, string shaDir)> ListInstalled();
        ModuleLockFile LoadLockFile();
        void PurgeCache(bool keepLockfilePinned = true);
        Task<ModuleLockFile> RestoreAndLockAsync(CancellationToken ct);
        void SaveLockFile(ModuleLockFile lockFile);
    }
}
