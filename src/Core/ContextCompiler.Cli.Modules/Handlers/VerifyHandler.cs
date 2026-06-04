using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContextCompiler.Cli.Modules.Handlers;

internal sealed class VerifyHandler(
    IModulesLoader moduleLoader,
    IOptions<ModulesConfig> cfgOptions,
    IIntegrityChecker integrityChecker,
    ILogger<VerifyHandler> logger
) : IVerifyHandler
{
    public Task<int> HandleAsync(string cfgFile)
    {
        try
        {
            _ = cfgFile;

            ModuleLockFile lf = moduleLoader.LoadLockFile();

            foreach (ModuleLockFile.LockedModule p in lf.Packages)
            {
                string nupkg = Path.Combine(
                    Path.GetFullPath(cfgOptions.Value.InstallRoot),
                    "_nupkg",
                    p.Id,
                    p.Version.Raw,
                    $"{p.Id}.{p.Version}.nupkg"
                );

                if (!File.Exists(nupkg))
                {
                    throw new InvalidOperationException($"Missing cached nupkg: {nupkg}");
                }

                string sha = integrityChecker.ComputeSha256Base64(nupkg);
                if (!string.Equals(sha, p.Checksum, StringComparison.Ordinal))
                {
                    throw new InvalidOperationException($"SHA mismatch for {p.Id} {p.Version}");
                }
            }

            Console.WriteLine("OK");
            return Task.FromResult(0);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return Task.FromResult(1);
        }
    }
}
