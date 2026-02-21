using System.Globalization;

namespace ContextCompiler.Modules.NuGet;

public static class Quarantine
{
    public static string MoveToQuarantine(string quarantineRoot, string packageId, string version, string filePath, string reason)
    {
        string ts = DateTime.UtcNow.ToString("yyyyMMdd-HHmmss", CultureInfo.InvariantCulture);
        string targetDir = Path.Combine(quarantineRoot, packageId, version, ts);
        _ = Directory.CreateDirectory(targetDir);
        string target = Path.Combine(targetDir, Path.GetFileName(filePath));
        File.Copy(filePath, target, overwrite: true);
        File.WriteAllText(Path.Combine(targetDir, "reason.txt"), reason);
        return targetDir;
    }
}
