using System.Reflection;
using System.Runtime.Loader;

namespace ContextCompiler.Infrastructure.PluginLoading;

public sealed class PluginLoadContext(string pluginMainAssemblyPath) : AssemblyLoadContext(isCollectible: false)
{
    private readonly AssemblyDependencyResolver _resolver = new(pluginMainAssemblyPath);

    protected override Assembly? Load(AssemblyName assemblyName)
    {
        string? path = _resolver.ResolveAssemblyToPath(assemblyName);
        return path is null ? null : LoadFromAssemblyPath(path);
    }
}
