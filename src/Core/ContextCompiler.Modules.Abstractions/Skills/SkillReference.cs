namespace ContextCompiler.Modules.Abstractions.Skills;

public sealed record SkillReference(string Id, string Provider, string? Version = null)
{
    public static SkillReference Parse(string value)
    {
        return TryParse(value, out SkillReference? reference) && reference is not null
            ? reference
            : throw new ArgumentException($"Invalid skill reference '{value}'. Expected '<skill-id>@<provider-id>[:version]'.", nameof(value));
    }

    public static bool TryParse(string value, out SkillReference? reference)
    {
        reference = null;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        string[] providerSplit = value.Split('@', 2, StringSplitOptions.TrimEntries);
        if (providerSplit.Length != 2 || string.IsNullOrWhiteSpace(providerSplit[0]) || string.IsNullOrWhiteSpace(providerSplit[1]))
        {
            return false;
        }

        string provider = providerSplit[1];
        string? version = null;
        int versionSeparator = provider.IndexOf(':', StringComparison.Ordinal);
        if (versionSeparator >= 0)
        {
            version = provider[(versionSeparator + 1)..];
            provider = provider[..versionSeparator];
        }

        if (string.IsNullOrWhiteSpace(provider))
        {
            return false;
        }

        reference = new SkillReference(providerSplit[0], provider, string.IsNullOrWhiteSpace(version) ? null : version);
        return true;
    }

    public override string ToString()
    {
        string versionSuffix = string.IsNullOrWhiteSpace(Version) ? "" : $":{Version}";
        return $"{Id}@{Provider}{versionSuffix}";
    }
}
