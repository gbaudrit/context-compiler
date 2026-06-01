namespace ContextCompiler.Skills.Abstractions;

public sealed record SkillInstallPlan(IReadOnlyList<SkillInstallPlanItem> Items);

public sealed record SkillInstallPlanItem(
    SkillReference Reference,
    string RequestedVersion,
    SkillInstallPlanSource Source,
    SkillRequirementIntent? Intent,
    string? Reason,
    IReadOnlyList<string> RequestedBy);

public enum SkillInstallPlanSource
{
    Configuration,
    ModuleDeclaration
}

public interface ISkillInstallPlanner
{
    SkillInstallPlan CreatePlan();
}
