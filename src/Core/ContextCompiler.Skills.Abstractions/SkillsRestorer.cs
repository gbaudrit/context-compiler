namespace ContextCompiler.Skills.Abstractions;

public sealed record SkillsRestoreResult(SkillInstallPlan Plan, SkillLockFile LockFile);

public interface ISkillsRestorer
{
    Task<SkillsRestoreResult> RestoreAsync(CancellationToken cancellationToken);
}
