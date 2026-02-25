using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Abstractions.Loading
{
    public interface IModulesLoader
    {
        Task LoadFromAssemblies(Assembly[] assemblies, IServiceCollection services);
        Task LoadFromFolder(string path, IServiceCollection services, CancellationToken cancellationToken);
    }
}
