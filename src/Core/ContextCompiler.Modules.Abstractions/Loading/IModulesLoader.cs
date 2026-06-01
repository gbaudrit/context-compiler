using System.Reflection;

using ContextCompiler.Abstractions.DependencyInjection;
using ContextCompiler.Modules.Abstractions.Configuration;

namespace ContextCompiler.Modules.Abstractions.Loading
{
    public interface IModulesLoader
    {
        bool Clean();
        Task LoadFromAssemblies(IContextCompilerBuilder contextCompilerBuilder, Assembly[] assemblies);
        Task<IEnumerable<Type>> LoadFromFolder(IContextCompilerBuilder contextCompilerBuilder, string path, CancellationToken cancellationToken);
        ModuleLockFile LoadLockFile();
        void SaveLockFile(ModuleLockFile lockFile);
        void SaveRunModules(IReadOnlyDictionary<string, string> runModules);
    }
}
