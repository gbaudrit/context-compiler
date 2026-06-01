using System.Reflection;

using ContextCompiler.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;

using Microsoft.Extensions.Options;
namespace ContextCompiler.Modules.Loader;

public sealed class ModuleAssemblyLoader(IOptions<ModulesConfig> configOptions, IWorkingFolder workingFolder, IDependenciesChecker dependenciesChecker) : IModuleAssemblyLoader
{
    public ValueTask<ILoadModuleAssemblyResult> LoadFromAssembly(string assemblyPath, CancellationToken ct)
    {
        string? installRoot = null;
        try
        {
            installRoot = Path.Combine(workingFolder.Path, configOptions.Value.InstallRoot.Replace('/', Path.DirectorySeparatorChar));
        }
        catch
        {
            // If we can't get install root, continue without it
        }

        ModuleLoadContext alc = new(dependenciesChecker, assemblyPath, installRoot);
        Assembly asm = alc.LoadFromAssemblyPath(assemblyPath);
        return LoadFromAssembly(asm, ct);
    }

    public ValueTask<ILoadModuleAssemblyResult> LoadFromAssembly(Assembly assembly, CancellationToken ct)
    {
        IEnumerable<Type> types = assembly.GetTypes();
        return !types.Any()
            ? ValueTask.FromResult<ILoadModuleAssemblyResult>(new LoadModuleAssemblyResult { Success = false, ErrorMessage = "No module type found in assembly.", Types = [] })
            : ValueTask.FromResult<ILoadModuleAssemblyResult>(new LoadModuleAssemblyResult { Success = true, ErrorMessage = null, Types = types });
    }
}
