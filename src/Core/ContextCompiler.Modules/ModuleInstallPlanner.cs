using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;

using Microsoft.Extensions.Options;

namespace ContextCompiler.Modules;

internal sealed class ModuleInstallPlanner(IOptions<ModulesConfig> configOptions) : IModuleInstallPlanner
{
    public ModuleInstallPlan CreatePlan(IReadOnlyDictionary<string, string>? runModules = null)
    {
        ModulesConfig config = configOptions.Value;
#pragma warning disable IDE0028
        Dictionary<string, MutableItem> items = new(StringComparer.OrdinalIgnoreCase);
#pragma warning restore IDE0028

        foreach (KeyValuePair<string, string> entry in config.Packages)
        {
            AddOrMerge(items, entry.Key, entry.Value, ModuleInstallPlanSource.Configuration, "config");
        }

        if (runModules is not null)
        {
            foreach (KeyValuePair<string, string> entry in runModules)
            {
                AddOrMerge(items, entry.Key, entry.Value, ModuleInstallPlanSource.RunModules, "run");
            }
        }

        IReadOnlyList<ModuleInstallPlanItem> planItems =
        [
            .. items.Values
                .OrderBy(x => x.Id, StringComparer.OrdinalIgnoreCase)
                .Select(x => new ModuleInstallPlanItem(
                    x.Id,
                    x.RequestedVersion,
                    x.Source,
                    [.. x.RequestedBy.OrderBy(y => y, StringComparer.OrdinalIgnoreCase)]))
        ];

        return new ModuleInstallPlan(planItems);
    }

    private static void AddOrMerge(
        Dictionary<string, MutableItem> items,
        string id,
        string requestedVersion,
        ModuleInstallPlanSource source,
        string requestedBy)
    {
        if (!items.TryGetValue(id, out MutableItem? existing))
        {
            items[id] = new MutableItem(id, requestedVersion, source, [requestedBy]);
            return;
        }

        if (!string.Equals(existing.RequestedVersion, requestedVersion, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException($"Conflicting versions requested for module '{id}': '{existing.RequestedVersion}' and '{requestedVersion}'.");
        }

        existing.Source = existing.Source == ModuleInstallPlanSource.Configuration
            ? ModuleInstallPlanSource.Configuration
            : source;
        _ = existing.RequestedBy.Add(requestedBy);
    }

    private sealed class MutableItem(
        string id,
        string requestedVersion,
        ModuleInstallPlanSource source,
        IEnumerable<string> requestedBy)
    {
        public string Id { get; } = id;
        public string RequestedVersion { get; } = requestedVersion;
        public ModuleInstallPlanSource Source { get; set; } = source;
        public HashSet<string> RequestedBy { get; } = new(requestedBy, StringComparer.OrdinalIgnoreCase);
    }
}
