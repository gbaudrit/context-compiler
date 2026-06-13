using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContextCompiler.Modules;

internal sealed class ModuleVersionOverrideResolver(
    IOptions<ModuleVersionOverridesConfig> overridesOptions,
    ILogger<ModuleVersionOverrideResolver> logger) : IModuleVersionOverrideResolver
{
    public string ResolveVersion(string packageKey, string packageId, string sourceId, string requestedVersion)
    {
        ModuleVersionOverridesConfig config = overridesOptions.Value;
        if (config.Overrides.Count == 0)
        {
            return requestedVersion;
        }

        string packageKeyWithSource = ModulePackageKeys.WithSource(packageId, sourceId);

        List<KeyValuePair<string, string>> matches =
        [
            .. config.Overrides
            .Where(x => ModulePatternMatches(x.Key, packageId, packageKeyWithSource, packageKey))
            .OrderByDescending(x => Specificity(x.Key))
            .ThenBy(x => x.Key, StringComparer.OrdinalIgnoreCase)
        ];

        if (matches.Count == 0)
        {
            return requestedVersion;
        }

        KeyValuePair<string, string> best = matches[0];

        logger.LogInformation(
            "Module {ModuleId}@{SourceId} version {RequestedVersion} overridden by {Pattern} -> {EffectiveVersion}",
            packageId,
            sourceId,
            requestedVersion,
            best.Key,
            best.Value);

        return best.Value;
    }

    private static bool ModulePatternMatches(string pattern, string packageId, string packageKeyWithSource, string originalPackageKey)
    {
        return Wildcard.IsMatch(pattern, packageId)
            || Wildcard.IsMatch(pattern, packageKeyWithSource)
            || Wildcard.IsMatch(pattern, originalPackageKey);
    }

    private static int Specificity(string pattern)
    {
        int wildcardCount = pattern.Count(c => c is '*' or '?');
        int sourceBonus = pattern.Contains('@') ? 1000 : 0;
        return sourceBonus + pattern.Length - (wildcardCount * 100);
    }
}
