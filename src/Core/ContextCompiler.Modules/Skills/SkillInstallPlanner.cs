using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Skills;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Skills;

internal sealed class SkillInstallPlanner(
    ISkillsLoadConfigProvider configProvider,
    IServiceProvider serviceProvider) : ISkillInstallPlanner
{
    public SkillInstallPlan CreatePlan()
    {
        SkillsConfig config = configProvider.Current;
        Dictionary<string, MutablePlanItem> items = [];

        foreach (KeyValuePair<string, string> configuredSkill in config.Items)
        {
            if (!SkillReference.TryParse(configuredSkill.Key, out SkillReference? reference) || reference is null)
            {
                throw new InvalidOperationException($"Unable to parse skill reference '{configuredSkill.Key}'. Expected '<skill-id>@<provider-id>[:version]'.");
            }

            ValidateTrust(config, reference);

            SkillReference effectiveReference = reference with { Version = reference.Version ?? configuredSkill.Value };
            AddOrMerge(
                items,
                effectiveReference,
                configuredSkill.Value,
                SkillInstallPlanSource.Configuration,
                null,
                null,
                "config");
        }

        foreach (ISkillRequirementsProvider provider in serviceProvider.GetServices<ISkillRequirementsProvider>())
        {
            string requestedBy = provider.GetType().FullName ?? provider.GetType().Name;
            foreach (SkillRequirement requirement in provider.GetSkillRequirements())
            {
                ValidateTrust(config, requirement.Reference);

                if (!ShouldIncludeDeclaration(config, requirement))
                {
                    continue;
                }

                string requestedVersion = requirement.Reference.Version ?? "latest";
                AddOrMerge(
                    items,
                    requirement.Reference with { Version = requestedVersion },
                    requestedVersion,
                    SkillInstallPlanSource.ModuleDeclaration,
                    requirement.Intent,
                    requirement.Reason,
                    requestedBy);
            }
        }

        IReadOnlyList<SkillInstallPlanItem> planItems =
        [
            .. items.Values
            .OrderBy(x => x.Reference.Provider, StringComparer.OrdinalIgnoreCase)
            .ThenBy(x => x.Reference.Id, StringComparer.OrdinalIgnoreCase)
            .Select(x => new SkillInstallPlanItem(
                x.Reference,
                x.RequestedVersion,
                x.Source,
                x.Intent,
                x.Reason,
                [.. x.RequestedBy.OrderBy(y => y, StringComparer.OrdinalIgnoreCase)]))
        ];

        return new SkillInstallPlan(planItems);
    }

    private static void ValidateTrust(SkillsConfig config, SkillReference reference)
    {
        if (config.Trust.BlockedProviders.Any(x => x.Equals(reference.Provider, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"Skill provider '{reference.Provider}' is blocked.");
        }

        if (config.Trust.BlockedSkills.Any(x => x.Equals(reference.Id, StringComparison.OrdinalIgnoreCase) || x.Equals(reference.ToString(), StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"Skill '{reference}' is blocked.");
        }

        if (config.Trust.RequireTrustedProvider
            && config.Trust.AllowedProviders.Count > 0
            && !config.Trust.AllowedProviders.Any(x => x.Equals(reference.Provider, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"Skill provider '{reference.Provider}' is not allowed by skills.trust.allowedProviders.");
        }
    }

    private static bool ShouldIncludeDeclaration(SkillsConfig config, SkillRequirement requirement)
    {
        string mode = config.Declarations.Mode;
        return !mode.Equals("Deny", StringComparison.OrdinalIgnoreCase)
            && (requirement.Intent != SkillRequirementIntent.Required || config.Declarations.AllowRequired)
            && (requirement.Intent != SkillRequirementIntent.Recommended || config.Declarations.AllowRecommended);
    }

    private static void AddOrMerge(
        Dictionary<string, MutablePlanItem> items,
        SkillReference reference,
        string requestedVersion,
        SkillInstallPlanSource source,
        SkillRequirementIntent? intent,
        string? reason,
        string requestedBy)
    {
        string key = $"{reference.Id}@{reference.Provider}".ToUpperInvariant();
        if (!items.TryGetValue(key, out MutablePlanItem? existing))
        {
            items[key] = new MutablePlanItem(reference, requestedVersion, source, intent, reason, [requestedBy]);
            return;
        }

        if (!string.Equals(existing.RequestedVersion, requestedVersion, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException($"Conflicting versions requested for skill {key}: '{existing.RequestedVersion}' and '{requestedVersion}'.");
        }

        existing.Source = existing.Source == SkillInstallPlanSource.Configuration
            ? SkillInstallPlanSource.Configuration
            : source;
        existing.Intent = MergeIntent(existing.Intent, intent);
        existing.Reason ??= reason;
        _ = existing.RequestedBy.Add(requestedBy);
    }

    private static SkillRequirementIntent? MergeIntent(SkillRequirementIntent? current, SkillRequirementIntent? next)
    {
        return current is null
            ? next
            : next is null
                ? current
                : current < next ? current : next;
    }

    private sealed class MutablePlanItem(
        SkillReference reference,
        string requestedVersion,
        SkillInstallPlanSource source,
        SkillRequirementIntent? intent,
        string? reason,
        IEnumerable<string> requestedBy)
    {
        public SkillReference Reference { get; } = reference;
        public string RequestedVersion { get; } = requestedVersion;
        public SkillInstallPlanSource Source { get; set; } = source;
        public SkillRequirementIntent? Intent { get; set; } = intent;
        public string? Reason { get; set; } = reason;
        public HashSet<string> RequestedBy { get; } = new(requestedBy, StringComparer.OrdinalIgnoreCase);
    }
}
