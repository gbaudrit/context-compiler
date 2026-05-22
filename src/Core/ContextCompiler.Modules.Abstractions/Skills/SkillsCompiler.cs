using ContextCompiler.Modules.Abstractions.Configuration;

namespace ContextCompiler.Modules.Abstractions.Skills;

public sealed record SkillsCompileResult(SkillInstallPlan Plan, SkillLockFile LockFile);

public interface ISkillsCompiler
{
    Task<SkillsCompileResult> CompileAsync(CancellationToken cancellationToken);
}
