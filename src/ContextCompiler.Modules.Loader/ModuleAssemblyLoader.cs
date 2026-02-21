using System.Reflection;

using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Loading;
namespace ContextCompiler.Modules.Loader;

public sealed class ModuleAssemblyLoader : IModuleAssemblyLoader
{
    public ValueTask<ILoadModuleAssemblyResult> LoadFromAssembly(string assemblyPath, CancellationToken ct)
    {
        ModuleLoadContext alc = new(assemblyPath);
        Assembly asm = alc.LoadFromAssemblyPath(assemblyPath);
        Type? t = asm.GetTypes().FirstOrDefault(x => typeof(IModule).IsAssignableFrom(x) && !x.IsAbstract);
        return t is null
            ? ValueTask.FromResult<ILoadModuleAssemblyResult>(new LoadModuleAssemblyResult { Success = false, ErrorMessage = "No module type found in assembly.", ModuleType = default })
            : ValueTask.FromResult<ILoadModuleAssemblyResult>(new LoadModuleAssemblyResult { Success = true, ErrorMessage = null, ModuleType = t });
    }
}
