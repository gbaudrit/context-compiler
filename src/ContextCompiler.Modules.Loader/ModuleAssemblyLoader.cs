using System.Reflection;

using ContextCompiler.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;
namespace ContextCompiler.Modules.Loader;

public sealed class ModuleAssemblyLoader(IModulesLoadConfigProvider configProvider, IWorkingFolder workingFolder) : IModuleAssemblyLoader
{
    public ValueTask<ILoadModuleAssemblyResult> LoadFromAssembly(string assemblyPath, CancellationToken ct)
    {
        string? installRoot = null;
        try
        {
            installRoot = Path.Combine(workingFolder.Path, configProvider.Current.InstallRoot);
        }
        catch
        {
            // If we can't get install root, continue without it
        }

        ModuleLoadContext alc = new(assemblyPath, installRoot);
        Assembly asm = alc.LoadFromAssemblyPath(assemblyPath);
        IEnumerable<Type> types = asm.GetTypes();
        return !types.Any()
            ? ValueTask.FromResult<ILoadModuleAssemblyResult>(new LoadModuleAssemblyResult { Success = false, ErrorMessage = "No module type found in assembly.", Types = [] })
            : ValueTask.FromResult<ILoadModuleAssemblyResult>(new LoadModuleAssemblyResult { Success = true, ErrorMessage = null, Types = types });
    }
}
