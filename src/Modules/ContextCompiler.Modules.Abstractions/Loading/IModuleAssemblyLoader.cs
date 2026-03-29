namespace ContextCompiler.Modules.Abstractions.Loading
{
    public interface IModuleAssemblyLoader
    {
        ValueTask<ILoadModuleAssemblyResult> LoadFromAssembly(string assemblyPath, CancellationToken ct);
    }
}
