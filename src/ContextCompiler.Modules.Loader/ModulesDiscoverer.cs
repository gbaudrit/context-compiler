using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Modules.Loader;

internal sealed class ModulesDiscoverer(IModuleAssemblyLoader moduleAssemblyLoader) : IModulesDiscoverer
{

    public async Task<IEnumerable<Type>> Discover(string rootPath, CancellationToken ct)
    {
        List<Type> discoveredModuleTypes = [];
        if (!Directory.Exists(rootPath))
        {
            throw new DirectoryNotFoundException($"Modules root directory not found: {rootPath}");
        }

        Directory.GetFiles(rootPath, "*.dll", SearchOption.AllDirectories)
            .AsParallel()
            .WithCancellation(ct)
            .ForAll(async path =>
            {
                try
                {
                    ILoadModuleAssemblyResult loadResult = await moduleAssemblyLoader.LoadFromAssembly(path, ct);
                    if (loadResult.Success)
                    {
                        discoveredModuleTypes.Add(loadResult.ModuleType);
                    }
                }
                catch (Exception ex)
                {
                    // Log and ignore individual module load failures
                    Console.Error.WriteLine($"Failed to load module from {path}: {ex}");
                }
            });

        return discoveredModuleTypes;

    }
}
