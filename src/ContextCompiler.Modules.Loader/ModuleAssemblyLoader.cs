using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;
namespace ContextCompiler.Modules.Loader;

public sealed class ModuleAssemblyLoader : IModuleAssemblyLoader
{
    public ValueTask<ILoadModuleAssemblyResult> LoadFromAssembly(string assemblyPath, CancellationToken ct)
    {
        ModuleLoadContext alc = new(assemblyPath);
        Assembly asm = alc.LoadFromAssemblyPath(assemblyPath);
        IEnumerable<Type> types = asm.GetTypes().Where(x => !x.IsAbstract);
        return !types.Any()
            ? ValueTask.FromResult<ILoadModuleAssemblyResult>(new LoadModuleAssemblyResult { Success = false, ErrorMessage = "No module type found in assembly.", Types = [] })
            : ValueTask.FromResult<ILoadModuleAssemblyResult>(new LoadModuleAssemblyResult { Success = true, ErrorMessage = null, Types = types });
    }
}
