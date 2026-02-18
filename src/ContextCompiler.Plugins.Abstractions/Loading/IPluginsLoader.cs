using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Plugins.Abstractions.Loading
{
    public interface IPluginsLoader
    {
        Task LoadFromFolder(string path, IServiceCollection services, CancellationToken cancellationToken);
    }
}
