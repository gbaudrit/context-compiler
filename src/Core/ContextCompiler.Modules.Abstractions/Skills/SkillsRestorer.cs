namespace ContextCompiler.Modules.Abstractions.Skills;

public sealed record SkillsRestoreResult(SkillInstallPlan Plan, SkillLockFile LockFile);

public interface ISkillsRestorer
{
    Task<SkillsRestoreResult> RestoreAsync(CancellationToken cancellationToken);
}
