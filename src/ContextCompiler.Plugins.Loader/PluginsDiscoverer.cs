using ContextCompiler.Plugins.Abstractions.Loading;

namespace ContextCompiler.Plugins.Loader;

internal sealed class PluginsDiscoverer(IPluginAssemblyLoader pluginAssemblyLoader) : IPluginsDiscoverer
{

    public async Task<IEnumerable<Type>> Discover(string rootPath, CancellationToken ct)
    {
        List<Type> discoveredPluginTypes = [];
        if (!Directory.Exists(rootPath))
        {
            throw new DirectoryNotFoundException($"Plugins root directory not found: {rootPath}");
        }

        Directory.GetFiles(rootPath, "*.dll", SearchOption.AllDirectories)
            .AsParallel()
            .WithCancellation(ct)
            .ForAll(async path =>
            {
                try
                {
                    ILoadPluginAssemblyResult loadResult = await pluginAssemblyLoader.LoadFromAssembly(path, ct);
                    if (loadResult.Success)
                    {
                        discoveredPluginTypes.Add(loadResult.PluginType);
                    }
                }
                catch (Exception ex)
                {
                    // Log and ignore individual plugin load failures
                    Console.Error.WriteLine($"Failed to load plugin from {path}: {ex}");
                }
            });

        return discoveredPluginTypes;

    }
}
