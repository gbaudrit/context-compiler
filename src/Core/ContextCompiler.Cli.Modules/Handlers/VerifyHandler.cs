using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContextCompiler.Cli.Modules.Handlers;

internal sealed class VerifyHandler(
    IModulesLoader moduleLoader,
    IOptions<ModulesConfig> cfgOptions,
    IIntegrityChecker integrityChecker,
    [FromKeyedServices(StoreKeys.Modules)] IStore modulesStore,
    ILogger<VerifyHandler> logger
) : IVerifyHandler
{
    public async Task<int> HandleAsync(string cfgFile)
    {
        try
        {
            _ = cfgFile;

            ModuleLockFile lf = moduleLoader.LoadLockFile();

            foreach (ModuleLockFile.LockedModule p in lf.Packages)
            {
                IStoreResource nupkg = modulesStore.Container.GetResource($"_nupkg/{p.Id}/{p.Version.Raw}/{p.Id}.{p.Version}.nupkg");

                if (!await nupkg.Exists())
                {
                    throw new InvalidOperationException($"Missing cached nupkg: {nupkg}");
                }

                string sha = integrityChecker.ComputeSha256Base64(nupkg.Uri.AbsolutePath);
                if (!string.Equals(sha, p.Checksum, StringComparison.Ordinal))
                {
                    throw new InvalidOperationException($"SHA mismatch for {p.Id} {p.Version}");
                }
            }

            Console.WriteLine("OK");
            return 0;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return 1;
        }
    }
}
