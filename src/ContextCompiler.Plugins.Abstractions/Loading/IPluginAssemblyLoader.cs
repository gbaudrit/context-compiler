namespace ContextCompiler.Plugins.Abstractions.Loading
{
    public interface IPluginAssemblyLoader
    {
        ValueTask<ILoadPluginAssemblyResult> LoadFromAssembly(string assemblyPath, CancellationToken ct);
    }
}
