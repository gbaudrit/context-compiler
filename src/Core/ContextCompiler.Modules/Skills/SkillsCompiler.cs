using System.Text.Json;

using ContextCompiler.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Skills;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Skills;

internal sealed class SkillsCompiler(
    ISkillsLoadConfigProvider configProvider,
    ISkillInstallPlanner planner,
    IServiceProvider serviceProvider,
    IWorkingFolder workingFolder) : ISkillsCompiler
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

    public async Task<SkillsCompileResult> CompileAsync(CancellationToken cancellationToken)
    {
        SkillsConfig config = configProvider.Current;
        SkillInstallPlan plan = planner.CreatePlan();

        if (config.Mode.Equals("Locked", StringComparison.OrdinalIgnoreCase))
        {
            SkillLockFile existingLockFile = LoadLockFile(config.LockFile);
            return new SkillsCompileResult(plan, existingLockFile);
        }

        if (config.Offline && plan.Items.Count > 0)
        {
            throw new InvalidOperationException("Skills compile is offline but the current plan requires skill provider fetches.");
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

            SkillPackage package = await provider.FetchAsync(descriptor, cancellationToken);
            lockFile.Skills.Add(new SkillLockFile.LockedSkill
            {
                Id = descriptor.Reference.Id,
                Provider = descriptor.Reference.Provider,
                RequestedVersion = item.RequestedVersion,
                ResolvedVersion = descriptor.ResolvedVersion,
                SourceUri = descriptor.SourceUri,
                Checksum = package.Checksum,
                CompiledPath = Path.GetRelativePath(workingFolder.Path, package.CompiledPath).Replace('\\', '/'),
                RequestedBy = [.. item.RequestedBy]
            });
        }

        SaveLockFile(config.LockFile, lockFile);
        return new SkillsCompileResult(plan, lockFile);
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
