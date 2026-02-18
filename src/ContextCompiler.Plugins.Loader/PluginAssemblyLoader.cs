using System.Reflection;

using ContextCompiler.Plugins.Abstractions;
using ContextCompiler.Plugins.Abstractions.Loading;
namespace ContextCompiler.Plugins.Loader;

public sealed class PluginAssemblyLoader : IPluginAssemblyLoader
{
    public ValueTask<ILoadPluginAssemblyResult> LoadFromAssembly(string assemblyPath, CancellationToken ct)
    {
        PluginLoadContext alc = new(assemblyPath);
        Assembly asm = alc.LoadFromAssemblyPath(assemblyPath);
        Type? t = asm.GetTypes().FirstOrDefault(x => typeof(IPlugin).IsAssignableFrom(x) && !x.IsAbstract); //&& x.GetCustomAttribute<CtxcPluginAttribute>() != null
        return t is null
            ? ValueTask.FromResult<ILoadPluginAssemblyResult>(new LoadPluginAssemblyResult { Success = false, ErrorMessage = "No plugin type found in assembly.", PluginType = default })
            : ValueTask.FromResult<ILoadPluginAssemblyResult>(new LoadPluginAssemblyResult { Success = true, ErrorMessage = null, PluginType = t });
    }
}
