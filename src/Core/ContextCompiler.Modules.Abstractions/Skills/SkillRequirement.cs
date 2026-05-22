namespace ContextCompiler.Modules.Abstractions.Skills;

public sealed record SkillRequirement(
    SkillReference Reference,
    SkillRequirementIntent Intent,
    string? Reason = null);

public enum SkillRequirementIntent
{
    Required,
    Recommended,
    Optional
}

public interface ISkillRequirementsProvider
{
    IReadOnlyList<SkillRequirement> GetSkillRequirements();
}
