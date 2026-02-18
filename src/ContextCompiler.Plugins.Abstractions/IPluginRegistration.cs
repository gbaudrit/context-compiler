using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Plugins.Abstractions
{
    public interface IPluginRegistration
    {
        IServiceCollection RegisterServices(IServiceCollection services);
    }
}
