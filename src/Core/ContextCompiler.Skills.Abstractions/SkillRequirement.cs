namespace ContextCompiler.Skills.Abstractions;

public sealed record SkillRequirement(
    SkillReference Reference,
    SkillRequirementIntent Intent,
    string? Reason = null)
{
    public static SkillRequirement Required(string reference, string? reason = null)
    {
        return Create(reference, SkillRequirementIntent.Required, reason);
    }

    public static SkillRequirement Recommended(string reference, string? reason = null)
    {
        return Create(reference, SkillRequirementIntent.Recommended, reason);
    }

    public static SkillRequirement Optional(string reference, string? reason = null)
    {
        return Create(reference, SkillRequirementIntent.Optional, reason);
    }

    public static SkillRequirement Required(SkillReference reference, string? reason = null)
    {
        return new SkillRequirement(reference, SkillRequirementIntent.Required, reason);
    }

    public static SkillRequirement Recommended(SkillReference reference, string? reason = null)
    {
        return new SkillRequirement(reference, SkillRequirementIntent.Recommended, reason);
    }

    public static SkillRequirement Optional(SkillReference reference, string? reason = null)
    {
        return new SkillRequirement(reference, SkillRequirementIntent.Optional, reason);
    }

    private static SkillRequirement Create(string reference, SkillRequirementIntent intent, string? reason)
    {
        return new SkillRequirement(SkillReference.Parse(reference), intent, reason);
    }
}

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
