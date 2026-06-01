using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;

namespace ContextCompiler.Modules.Loader;

internal sealed class ModulesDiscoverer(IModuleAssemblyLoader moduleAssemblyLoader) : IModulesDiscoverer
{

    public async Task<IEnumerable<Type>> Discover(string rootPath, string packageId, CancellationToken ct)
    {
        List<Type> discoveredModuleTypes = [];
        if (!Directory.Exists(rootPath))
        {
            throw new DirectoryNotFoundException($"Modules root directory not found: {rootPath}");
        }

        // Find the main module assemblies (in lib/ folders, not dependencies in the root)
        string[] moduleDlls = FindModuleAssemblies(rootPath, packageId);

        foreach (string path in moduleDlls)
        {
            if (ct.IsCancellationRequested)
            {
                break;
            }

            try
            {
                ILoadModuleAssemblyResult loadResult = await moduleAssemblyLoader.LoadFromAssembly(path, ct);
                if (loadResult.Success)
                {
                    discoveredModuleTypes.AddRange(loadResult.Types);

                    await DiscoverPack(discoveredModuleTypes, loadResult, ct);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to load module from {path}: {ex}");
            }
        }

        return discoveredModuleTypes;
    }

    private async Task DiscoverPack(List<Type> discoveredModuleTypes, ILoadModuleAssemblyResult loadResult, CancellationToken ct)
    {
        IEnumerable<Type> packsType = loadResult.Types.Where(t => typeof(IPackModule).IsAssignableFrom(t));
        if (!packsType.Any())
        {
            return;
        }
        foreach (Type packType in packsType)
        {
            Console.WriteLine($"Discovered module pack: {packType.FullName}");
            IPackModule packInstance = (IPackModule)Activator.CreateInstance(packType)!;
            IEnumerable<Assembly> packAssemblies = packInstance.Discover();

            foreach (Assembly packAssembly in packAssemblies)
            {
                ILoadModuleAssemblyResult packLoadResult = await moduleAssemblyLoader.LoadFromAssembly(packAssembly.Location, ct);
                discoveredModuleTypes.AddRange(packLoadResult.Types);

                await DiscoverPack(discoveredModuleTypes, packLoadResult, ct);
            }
        }
    }

    private static string[] FindModuleAssemblies(string rootPath, string packageId)
    {
        Matcher matcher = new();
        _ = matcher.AddInclude($"**/{packageId}.dll");

        PatternMatchingResult result = matcher.Execute(new DirectoryInfoWrapper(new DirectoryInfo(rootPath)));

        return [.. result.Files.Select(f => Path.Combine(rootPath, f.Path))];
    }
}
