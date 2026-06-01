using System.Reflection;

namespace ContextCompiler.Modules.Abstractions.Loading
{
    public interface IModuleAssemblyLoader
    {
        ValueTask<ILoadModuleAssemblyResult> LoadFromAssembly(string assemblyPath, CancellationToken ct);
        ValueTask<ILoadModuleAssemblyResult> LoadFromAssembly(Assembly assembly, CancellationToken ct);
    }
}
