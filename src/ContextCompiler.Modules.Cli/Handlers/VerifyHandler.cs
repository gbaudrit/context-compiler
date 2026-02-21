using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Cli.Handlers;

internal sealed class VerifyHandler(
    IModulesManager moduleManager,
    IModulesLoadConfigProvider cfgProvider,
    ILogger<VerifyHandler> logger
) : IVerifyHandler
{
    public Task<int> HandleAsync(string cfgFile)
    {
        try
        {
            _ = cfgFile;

            ModuleLockFile lf = moduleManager.LoadLockFile();

            foreach (ModuleLockFile.LockedModule p in lf.Packages)
            {
                string nupkg = Path.Combine(
                    Path.GetFullPath(cfgProvider.Current.InstallRoot),
                    "_nupkg",
                    p.Id,
                    p.Version,
                    $"{p.Id}.{p.Version}.nupkg"
                );

                if (!File.Exists(nupkg))
                {
                    throw new InvalidOperationException($"Missing cached nupkg: {nupkg}");
                }

                string sha = Loader.Integrity.ComputeSha256Base64(nupkg);
                if (!string.Equals(sha, p.Sha256, StringComparison.Ordinal))
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
