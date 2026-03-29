using System.Reflection;

using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;

using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;

namespace ContextCompiler.Modules.Loader;

internal sealed class ModulesDiscoverer(IModuleAssemblyLoader moduleAssemblyLoader, IModulesLoadConfigProvider modulesLoadConfigProvider) : IModulesDiscoverer
{

    public async Task<IEnumerable<Type>> Discover(string rootPath, CancellationToken ct)
    {
        List<Type> discoveredModuleTypes = [];
        if (!Directory.Exists(rootPath))
        {
            throw new DirectoryNotFoundException($"Modules root directory not found: {rootPath}");
        }

        // Find the main module assemblies (in lib/ folders, not dependencies in the root)
        string[] moduleDlls = FindModuleAssemblies(rootPath);

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
        IEnumerable<Type> packsType = loadResult.Types.Where(t => typeof(IPack).IsAssignableFrom(t));
        if (!packsType.Any())
        {
            return;
        }
        foreach (Type packType in packsType)
        {
            Console.WriteLine($"Discovered module pack: {packType.FullName}");
            IPack packInstance = (IPack)Activator.CreateInstance(packType)!;
            IEnumerable<Assembly> packAssemblies = packInstance.Discover();

            foreach (Assembly packAssembly in packAssemblies)
            {
                ILoadModuleAssemblyResult packLoadResult = await moduleAssemblyLoader.LoadFromAssembly(packAssembly.Location, ct);
                discoveredModuleTypes.AddRange(packLoadResult.Types);

                await DiscoverPack(discoveredModuleTypes, packLoadResult, ct);
            }
        }
    }

    private string[] FindModuleAssemblies(string rootPath)
    {
        Matcher matcher = new();


        foreach (KeyValuePair<string, string> pair in modulesLoadConfigProvider.Current.Packages)
        {
            string id = pair.Key;
            id = id.Split('@').First();
            _ = matcher.AddInclude($"**/{id}.dll");
        }

        PatternMatchingResult result = matcher.Execute(new DirectoryInfoWrapper(new DirectoryInfo(rootPath)));

        return [.. result.Files.Select(f => Path.Combine(rootPath, f.Path))];
    }
}
