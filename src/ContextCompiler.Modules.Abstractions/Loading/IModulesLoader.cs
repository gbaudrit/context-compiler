using System.Reflection;

using ContextCompiler.Modules.Abstractions.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Abstractions.Loading
{
    public interface IModulesLoader
    {
        Task LoadFromAssemblies(Assembly[] assemblies, IServiceCollection services);
        Task<IEnumerable<Type>> LoadFromFolder(string path, IServiceCollection services, CancellationToken cancellationToken);
        ModuleLockFile LoadLockFile();
        void SaveLockFile(ModuleLockFile lockFile);
    }
}
