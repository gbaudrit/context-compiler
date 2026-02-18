using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Plugins.Abstractions.Loading
{
    public interface IPluginRegistryBuilder
    {
        void RegisterPluginServices(IServiceCollection services, IEnumerable<Type> types);
    }
}
