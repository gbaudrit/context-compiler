using System.Reflection;
using System.Runtime.Loader;

namespace ContextCompiler.Modules.Loader;

public sealed class ModuleLoadContext(string moduleMainAssemblyPath) : AssemblyLoadContext(isCollectible: false)
{
    private readonly AssemblyDependencyResolver _resolver = new(moduleMainAssemblyPath);

    protected override Assembly? Load(AssemblyName assemblyName)
    {
        string? path = _resolver.ResolveAssemblyToPath(assemblyName);
        return path is null ? null : LoadFromAssemblyPath(path);
    }
}
