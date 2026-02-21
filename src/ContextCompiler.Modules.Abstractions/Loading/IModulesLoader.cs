using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Abstractions.Loading
{
    public interface IModulesLoader
    {
        Task LoadFromFolder(string path, IServiceCollection services, CancellationToken cancellationToken);
    }
}
