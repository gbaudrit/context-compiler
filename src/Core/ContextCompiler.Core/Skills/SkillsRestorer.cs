using System.Text.Json;

using ContextCompiler.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Skills;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Skills;

internal sealed class SkillsRestorer(
    ISkillsLoadConfigProvider configProvider,
    ISkillInstallPlanner planner,
    IServiceProvider serviceProvider,
    IWorkingFolder workingFolder) : ISkillsRestorer
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

    public async Task<SkillsRestoreResult> RestoreAsync(CancellationToken cancellationToken)
    {
        ISkillsLoadConfig config = configProvider.Current;
        SkillInstallPlan plan = planner.CreatePlan();

        if (config.Mode.Equals("Locked", StringComparison.OrdinalIgnoreCase))
        {
            SkillLockFile existingLockFile = LoadLockFile(config.LockFile);
            return new SkillsRestoreResult(plan, existingLockFile);
        }

        if (config.Offline && plan.Items.Count > 0)
        {
            throw new InvalidOperationException("Skills restore is offline but the current plan requires skill provider fetches.");
        }

        SkillLockFile lockFile = new()
        {
            FormatVersion = 1,
            GeneratedAt = DateTime.UtcNow,
            Skills = []
        };

        foreach (SkillInstallPlanItem item in plan.Items)
        {
            cancellationToken.ThrowIfCancellationRequested();

            ISkillProvider provider = ResolveProvider(item.Reference.Provider);
            SkillDescriptor descriptor = await provider.ResolveAsync(item.Reference, cancellationToken)
                ?? throw new InvalidOperationException($"Skill '{item.Reference}' was not found by provider '{item.Reference.Provider}'.");

            SkillPackage package = await provider.RestoreAsync(descriptor, cancellationToken);
            lockFile.Skills.Add(new SkillLockFile.LockedSkill
            {
                Id = descriptor.Reference.Id,
                Provider = descriptor.Reference.Provider,
                RequestedVersion = item.RequestedVersion,
                ResolvedVersion = descriptor.ResolvedVersion,
                SourceUri = descriptor.SourceUri,
                Checksum = package.Checksum,
                CachePath = package.CachePath.Uri.AbsolutePath,
                RequestedBy = [.. item.RequestedBy],
                Files = [.. package.Files.Select(f => f.Uri.AbsolutePath)]
            });
        }

        SaveLockFile(config.LockFile, lockFile);
        return new SkillsRestoreResult(plan, lockFile);
    }

    private ISkillProvider ResolveProvider(string providerId)
    {
        return serviceProvider.GetServices<ISkillProvider>()
            .FirstOrDefault(x => x.ProviderId.Equals(providerId, StringComparison.OrdinalIgnoreCase))
            ?? throw new InvalidOperationException($"No ISkillProvider registered for provider '{providerId}'. Install the provider module first.");
    }

    private void SaveLockFile(string lockFilePath, SkillLockFile lockFile)
    {
        string path = ResolveWorkspacePath(lockFilePath);

        _ = Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, JsonSerializer.Serialize(lockFile, JsonOptions));
    }

    private SkillLockFile LoadLockFile(string lockFilePath)
    {
        string path = ResolveWorkspacePath(lockFilePath);
        return File.Exists(path)
            ? JsonSerializer.Deserialize<SkillLockFile>(File.ReadAllText(path), JsonOptions) ?? new SkillLockFile()
            : throw new InvalidOperationException($"Skills mode is Locked but lock file was not found: {path}");
    }

    private string ResolveWorkspacePath(string path)
    {
        return Path.IsPathRooted(path)
            ? path
            : Path.GetFullPath(Path.Combine(workingFolder.Path, path.Replace('/', Path.DirectorySeparatorChar)));
    }
}
