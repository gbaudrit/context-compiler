using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;

using Microsoft.Extensions.Options;

namespace ContextCompiler.Modules;

public sealed class TrustPolicy(IOptions<ModulesConfig> cfgOptions) : ITrustPolicy
{
    private ModulesConfig Cfg => cfgOptions.Value;

    public void ValidateSource(ModuleSource source)
    {
        if (Cfg.Trust.RequireTrustedSource && !source.Trusted)
        {
            throw new InvalidOperationException($"Untrusted source is not allowed: {source.Name}");
        }
    }
    public void ValidatePackageId(string packageId)
    {
        if (Cfg.Trust.BlockedPackageIds.Any(p => Wildcard.IsMatch(p, packageId)))
        {
            throw new InvalidOperationException($"Package is blocked by policy: {packageId}");
        }

        if (Cfg.Trust.AllowedPackageIds.Count > 0 && !Cfg.Trust.AllowedPackageIds.Any(p => Wildcard.IsMatch(p, packageId)))
        {
            throw new InvalidOperationException($"Package is not allowlisted: {packageId}");
        }
    }
    public void ValidateAuthorsAndRepositoryUrl(string authors, string? repoUrl)
    {
        if (Cfg.Trust.AllowedAuthors.Count > 0)
        {
            bool ok = Cfg.Trust.AllowedAuthors.Any(a => string.Equals(a, authors, StringComparison.OrdinalIgnoreCase))
              || Cfg.Trust.AllowedAuthors.Any(a => authors.Split(',').Any(x => string.Equals(x.Trim(), a, StringComparison.OrdinalIgnoreCase)));
            if (!ok)
            {
                throw new InvalidOperationException($"Authors not allowed by policy: {authors}");
            }
        }
        if (Cfg.Trust.AllowedRepositoryPrefixes.Count > 0)
        {
            if (string.IsNullOrWhiteSpace(repoUrl))
            {
                throw new InvalidOperationException("Repository URL required by policy but missing.");
            }

            if (!Cfg.Trust.AllowedRepositoryPrefixes.Any(p => repoUrl.StartsWith(p, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"Repository URL not allowed: {repoUrl}");
            }
        }
    }
    public void ValidateSignature(bool isSigned, string? note = null)
    {
        if (Cfg.Trust.RequireSignedPackages && !isSigned)
        {
            throw new InvalidOperationException($"Unsigned package rejected by policy. {note}");
        }
    }
}
