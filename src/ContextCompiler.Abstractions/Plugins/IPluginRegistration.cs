using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Abstractions.Plugins
{
    public interface IPluginRegistration
    {
        IServiceCollection RegisterServices(IServiceCollection services);
    }
}
