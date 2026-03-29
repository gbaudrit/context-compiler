using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;

namespace ContextCompiler.Modules;

public sealed class TrustPolicy(IModulesLoadConfigProvider cfg) : ITrustPolicy
{
    public void ValidateSource(ModuleSource source)
    {
        if (cfg.Current.Trust.RequireTrustedSource && !source.Trusted)
        {
            throw new InvalidOperationException($"Untrusted source is not allowed: {source.Name}");
        }
    }
    public void ValidatePackageId(string packageId)
    {
        if (cfg.Current.Trust.BlockedPackageIds.Any(p => Wildcard.IsMatch(p, packageId)))
        {
            throw new InvalidOperationException($"Package is blocked by policy: {packageId}");
        }

        if (cfg.Current.Trust.AllowedPackageIds.Count > 0 && !cfg.Current.Trust.AllowedPackageIds.Any(p => Wildcard.IsMatch(p, packageId)))
        {
            throw new InvalidOperationException($"Package is not allowlisted: {packageId}");
        }
    }
    public void ValidateAuthorsAndRepositoryUrl(string authors, string? repoUrl)
    {
        if (cfg.Current.Trust.AllowedAuthors.Count > 0)
        {
            bool ok = cfg.Current.Trust.AllowedAuthors.Any(a => string.Equals(a, authors, StringComparison.OrdinalIgnoreCase))
              || cfg.Current.Trust.AllowedAuthors.Any(a => authors.Split(',').Any(x => string.Equals(x.Trim(), a, StringComparison.OrdinalIgnoreCase)));
            if (!ok)
            {
                throw new InvalidOperationException($"Authors not allowed by policy: {authors}");
            }
        }
        if (cfg.Current.Trust.AllowedRepositoryPrefixes.Count > 0)
        {
            if (string.IsNullOrWhiteSpace(repoUrl))
            {
                throw new InvalidOperationException("Repository URL required by policy but missing.");
            }

            if (!cfg.Current.Trust.AllowedRepositoryPrefixes.Any(p => repoUrl.StartsWith(p, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"Repository URL not allowed: {repoUrl}");
            }
        }
    }
    public void ValidateSignature(bool isSigned, string? note = null)
    {
        if (cfg.Current.Trust.RequireSignedPackages && !isSigned)
        {
            throw new InvalidOperationException($"Unsigned package rejected by policy. {note}");
        }
    }
}
